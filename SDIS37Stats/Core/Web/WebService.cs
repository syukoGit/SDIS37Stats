namespace SDIS37Stats.Core.Web
{
    using System;
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
        /// Initializes a new instance of the <see cref="WebService" /> class.
        /// </summary>
        /// <param name="username">username used for connection</param>
        /// <param name="password">password used for connection</param>
        public WebService(string username, string password)
        {
            Username = username;
            Password = password;

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
        }

        /// <summary>
        /// Refresh the <see cref="System.Windows.Forms.WebBrowser"/>.
        /// </summary>
        public void Refresh()
        {
            Console.Out.WriteLine("Refresh");
            this.WebBrowser.Url = new Uri(WebServiceMainPageURL);
        }

        #endregion

        #region Private

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
                if (this.WebBrowser.Url.AbsoluteUri == WebServicesLoginURL)
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

                    HtmlDocument document = WebBrowser.Document;

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
                else
                {
                    Console.Out.WriteLine("Connexion réussite");

                    this.connectionState = 2;

                    HtmlDocument document = WebBrowser.Document;

                    if (document == null)
                    {
                        Console.Out.WriteLine("Document null");
                    }
                    else if (document.Url.AbsoluteUri == WebServiceMainPageURL)
                    {
                        this.OnMainPageLoaded?.Invoke(WebBrowser.Document);
                        this.WebBrowser.Navigate(WebServiceStatsForOperationPerHourURL);
                    }
                    else if (document.Url.AbsoluteUri == WebServiceStatsForOperationPerHourURL)
                    {
                        this.OnNbOperationPerHourUpdated?.Invoke(WebBrowser.Document);
                        this.WebBrowser.ScriptErrorsSuppressed = true;
                        this.WebBrowser.Navigate(WebServiceRecentOperationListURL);
                    }
                    else if (document.Url.AbsoluteUri == WebServiceRecentOperationListURL)
                    {
                        this.WebBrowser.ScriptErrorsSuppressed = false;
                        this.OnRecentOperationListUpdated?.Invoke(WebBrowser.Document);
                        this.WebBrowser.Navigate(WebServiceFirefighterAvailabilityURL);
                    }
                    else if (document.Url.AbsoluteUri == WebServiceFirefighterAvailabilityURL)
                    {
                        this.OnListFirefighterAvailabilityUpdated?.Invoke(WebBrowser.Document);

                        string postData = "date=" + DateTime.Now.ToString("dd/MM/yyyy") + "&rbcsp=SDIS";
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postData);
                        this.WebBrowser.Navigate(WebServiceNbOperationsURl, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");
                    }
                    else if (document.Url.AbsoluteUri == WebServiceNbOperationsURl)
                    {
                        this.OnNbOperationInDayUpdated?.Invoke(WebBrowser.Document);
                    }
                    else
                    {
                        Console.Out.WriteLine("Page inconnue : " + document.Url.AbsoluteUri);
                    }
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
