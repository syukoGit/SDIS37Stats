namespace SDIS37Stats.Core.Web
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Class managing a connection with the GipsiWeb webservice of the SDIS37.
    /// </summary>
    /// <remarks>
    /// It uses a <see cref="System.Windows.Forms.WebBrowser"/> so objects can disposable.
    /// </remarks>
    class WebService : WebServiceURL, IDisposable
    {
        /// <summary>
        /// Public string for save the username used for connection.
        /// </summary>
        public static string Username { get; set; }

        /// <summary>
        /// Public string for save the password used for connection.
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// Private integer for get and set a connection state.
        /// </summary>
        /// <remarks>
        /// 0 : no connection.
        /// 1 : attempt connection.
        /// 2 : connection success.
        /// </remarks>
        private int connectionState = 0;

        /// <summary>
        /// Gets or sets a boolean if a web page is during loading.
        /// </summary>
        private bool webPageDuringLoading = false;

        /// <summary>
        /// Private queue for set and get a url queue to execute.
        /// </summary>
        private readonly Queue<(string url, string postData)> urlQueue = new Queue<(string, string)>();

        public delegate void OnMainPageLoadedHandler(HtmlDocument htmlDocument);
        public event OnMainPageLoadedHandler OnMainPageLoaded;

        public delegate void OnNbOperationInDayUpdatedHandler(HtmlDocument htmlDocument);
        public event OnNbOperationInDayUpdatedHandler OnNbOperationInDayUpdated;

        public delegate void OnNbOperationPerHourUpdatedHandler(HtmlDocument htmlDocument);
        public event OnNbOperationPerHourUpdatedHandler OnNbOperationPerHourUpdated;

        public delegate void OnListRecentOperationUpdatedHandler(HtmlDocument htmlDocument);
        public event OnListRecentOperationUpdatedHandler OnRecentOperationListUpdated;

        public delegate void OnListFirefighterAvailabilityUpdatedHandler(HtmlDocument htmlDocument);
        public event OnListFirefighterAvailabilityUpdatedHandler OnListFirefighterAvailabilityUpdated;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebService" /> class.
        /// </summary>
        public WebService()
        {
            this.WebBrowser = new WebBrowser();

            this.WebBrowser.DocumentCompleted += this.WebBrowser_DocumentCompleted;

            this.WebBrowser.Url = new Uri(WebServiceMainPageURL);
        }

        /// <summary>
        /// Gets the <see cref="System.Windows.Forms.WebBrowser"/> used for connection.
        /// </summary>
        public WebBrowser WebBrowser { get; private set; }

        #region Public
        /// <summary>
        /// Dispose all objects disposable.
        /// </summary>
        public void Dispose()
        {
            this.WebBrowser?.Dispose();
        }

        /// <summary>
        /// Clear session by deleting the authentication cache.
        /// </summary>
        public void ClearSession()
        {
            Console.Out.WriteLine("Clear authentication cache");
            this.WebBrowser.Document.ExecCommand("ClearAuthenticationCache", false, null);
            this.urlQueue.Enqueue((WebServicesLoginURL, null));

            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Refreshed the all values used by statistics class.
        /// </summary>
        public void RefreshAllValue()
        {
            Console.Out.WriteLine("Refresh");

            string postDataNbOperationInDay = "date=" + DateTime.Now.ToString("dd/MM/yyyy") + "&rbcsp=SDIS";

            this.urlQueue.Enqueue((WebServiceStatsForOperationPerHourURL, null));
            this.urlQueue.Enqueue((WebServiceRecentOperationListURL, null));
            this.urlQueue.Enqueue((WebServiceFirefighterAvailabilityURL, null));
            this.urlQueue.Enqueue((WebServiceNbOperationInDayURL, postDataNbOperationInDay));

            this.NavigateToNextUrl();
        }

        #endregion

        #region Private
        private void NavigateToNextUrl()
        {
            if (this.urlQueue.Count > 0 && !this.webPageDuringLoading)
            {
                this.webPageDuringLoading = true;

                var (url, postData) = this.urlQueue.Dequeue();
                if (string.IsNullOrEmpty(postData))
                {
                    this.WebBrowser.ScriptErrorsSuppressed = url == WebServiceRecentOperationListURL;
                    this.WebBrowser.Navigate(url);
                }
                else
                {
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postData);
                    this.WebBrowser.Navigate(url, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");
                }

                Console.Out.WriteLine("Requete http : " + url);
            }
        }

        /// <summary>
        /// Called when the <see cref="WebBrowser"/> loaded the <see cref="WebServiceURL.WebServicesLoginURL"/> url.
        /// </summary>
        private void LoginPageLoaded(HtmlDocument document)
        {
            if (this.connectionState == 1)
            {
                Console.Out.WriteLine("Connexion impossible");
                return;
            }

            Console.Out.WriteLine("Tentative de connexion");

            this.connectionState = 1;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                var getCredentials = new Controls.GetCredentials();
                _ = getCredentials.ShowDialog();

                var (Username, Password) = getCredentials.Credentials;
                WebService.Username = Username;
                WebService.Password = Password;
            }

            if (document != null)
            {
                document.All["username"].SetAttribute("value", Username);
                document.All["password"].SetAttribute("value", Password);

                HtmlElement buttonElem = null;
                foreach (HtmlElement item in document.GetElementsByTagName("button"))
                {
                    if (item.InnerText == "Se connecter")
                    {
                        buttonElem = item;
                        break;
                    }
                }

                buttonElem?.InvokeMember("click");
            }
        }

        private void MainPageLoaded(HtmlDocument document)
        {
            this.OnMainPageLoaded?.Invoke(document);
            this.NavigateToNextUrl();
        }

        private void NbOperationPerHourLoaded(HtmlDocument document)
        {
            this.OnNbOperationPerHourUpdated?.Invoke(document);
            this.NavigateToNextUrl();
        }

        private void RecentOperationListLoaded(HtmlDocument document)
        {
            this.OnRecentOperationListUpdated?.Invoke(document);
            this.NavigateToNextUrl();
        }

        private void FirefighterAvailabilitiesLoaded(HtmlDocument document)
        {
            this.OnListFirefighterAvailabilityUpdated?.Invoke(document);
            this.NavigateToNextUrl();
        }

        private void NbOperationInDayLoaded(HtmlDocument document)
        {
            this.OnNbOperationInDayUpdated?.Invoke(document);
            this.NavigateToNextUrl();
        }
        #endregion

        #region Event
        /// <summary>
        /// Event called when the document is load by the <see cref="System.Windows.Forms.WebBrowser"/>.
        /// </summary>
        /// <param name="sender">Object who send the event.</param>
        /// <param name="e">Event's arguments</param>
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                HtmlDocument document = WebBrowser.Document;

                this.webPageDuringLoading = false;

                if (document == null)
                {

                }
                else if (document.Url.AbsoluteUri == WebServicesLoginURL)
                {
                    this.LoginPageLoaded(document);
                }
                else if (document.Url.AbsoluteUri == WebServiceMainPageURL)
                {
                    this.MainPageLoaded(document);
                }
                else if (document.Url.AbsoluteUri == WebServiceStatsForOperationPerHourURL)
                {
                    this.NbOperationPerHourLoaded(document);
                }
                else if (document.Url.AbsoluteUri == WebServiceRecentOperationListURL)
                {
                    this.RecentOperationListLoaded(document);
                }
                else if (document.Url.AbsoluteUri == WebServiceFirefighterAvailabilityURL)
                {
                    this.FirefighterAvailabilitiesLoaded(document);
                }
                else if (document.Url.AbsoluteUri == WebServiceNbOperationInDayURL)
                {
                    this.NbOperationInDayLoaded(document);
                }
                else
                {
                    Console.Out.WriteLine("Page inconnue : " + document.Url.AbsoluteUri);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
