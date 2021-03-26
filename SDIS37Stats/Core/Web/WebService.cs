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
    class WebService : IDisposable
    {
        private static readonly List<string> UrlWichUseJS = new();

        /// <summary>
        /// Private queue for set and get a url queue to execute.
        /// </summary>
        private readonly Queue<(URL url, Dictionary<string, string> queryParams, Dictionary<string, string> postDatas)> urlQueue = new();

        private int connectionState = 0;

        /// <summary>
        /// Private integer for get and set a connection state.
        /// </summary>
        /// <remarks>
        /// 0 : no connection.
        /// 1 : attempt connection.
        /// 2 : connection success.
        /// </remarks>
        private int ConnectionState
        {
            get
            {
                return this.connectionState;
            }
            set
            {
                this.connectionState = value;
                switch (this.connectionState)
                {
                    default:
                    case 0:
                    case 1:
                        this.isLogged = false;
                        break;
                    case 2:
                        Syst.Log.WriteLog(Syst.Log.TYPE.Normal, "Successful authentication");
                        this.isLogged = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Started date and time to http request is send.
        /// Used for measure the response time of the last http request.
        /// </summary>
        private DateTime startedTimeHttpRequest = DateTime.MinValue;

        /// <summary>
        /// Gets or sets a boolean if a web page is during loading.
        /// </summary>
        private bool webPageDuringLoading = false;

        private bool isLogged = false;

        public delegate void OnMainPageLoadedHandler(HtmlDocument htmlDocument);
        public event OnMainPageLoadedHandler OnMainPageLoaded;

        public delegate void OnNbOperationInDayUpdatedHandler(HtmlDocument htmlDocument);
        public event OnNbOperationInDayUpdatedHandler OnNbOperationInDayUpdated;

        public delegate void OnNbOperationPerHourUpdatedHandler(HtmlDocument htmlDocument);
        public event OnNbOperationPerHourUpdatedHandler OnNbOperationPerHourUpdated;

        public delegate void OnOperationListUpdatedHandler(HtmlDocument htmlDocument);
        public event OnOperationListUpdatedHandler OnOperationListUpdated;

        public delegate void OnOperationListOfUserFirehouseUpdatedHandler(HtmlDocument htmlDocument);
        public event OnOperationListOfUserFirehouseUpdatedHandler OnOperationListOfUserFirehouseUpdated;

        public delegate void OnListFirefighterAvailabilityUpdatedHandler(HtmlDocument htmlDocument);
        public event OnListFirefighterAvailabilityUpdatedHandler OnListFirefighterAvailabilityUpdated;

        public delegate void OnUrlQueueEmptyHandler();
        public event OnUrlQueueEmptyHandler OnUrlQueueEmpty;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebService" /> class.
        /// </summary>
        public WebService()
        {
            WebService.UrlWichUseJS.Add(WebServiceURL.WebServiceOperationListURL.Url);
            WebService.UrlWichUseJS.Add(WebServiceURL.WebServiceOperationListOfTheUserFirehouseURL.Url);

            this.WebBrowser = new WebBrowser();

            this.WebBrowser.DocumentCompleted += this.WebBrowser_DocumentCompleted;

            this.WebBrowser.Url = new Uri(WebServiceURL.WebServiceMainPageURL.GetAbsoluteUrl(null));
        }

        /// <summary>
        /// Gets or sets the username used for connection.
        /// </summary>
        public static string Username { get; set; }

        /// <summary>
        /// Gets or sets the password used for connection.
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// Gets the <see cref="System.Windows.Forms.WebBrowser"/> used for connection.
        /// </summary>
        public WebBrowser WebBrowser { get; private set; }

        public Queue<(URL url, Dictionary<string, string> queryParams, Dictionary<string, string> postDatas)> UrlQueue => this.urlQueue;

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
            Syst.Log.WriteLog(Syst.Log.TYPE.Normal, "WebService -> Clear authentification cache");
            this.WebBrowser.Document.ExecCommand("ClearAuthenticationCache", false, null);
            this.UrlQueue.Enqueue((WebServiceURL.WebServicesLoginURL, null, null));

            this.NavigateToNextUrl();
        }
        #endregion

        /// <summary>
        /// Sets the next url of the queue to <see cref="WebBrowser"/>
        /// </summary>
        public void NavigateToNextUrl()
        {
            if (this.UrlQueue.Count > 0)
            {
                if (!this.webPageDuringLoading && this.isLogged)
                {
                    this.webPageDuringLoading = true;

                    this.startedTimeHttpRequest = DateTime.Now;

                    var (url, queryParams, postDatas) = this.UrlQueue.Dequeue();

                    this.WebBrowser.ScriptErrorsSuppressed = !url.UseJS;

                    var (strUrl, strPostDatas) = url.GetAbsoluteUrlAndPostData(queryParams, postDatas);

                    if (string.IsNullOrEmpty(strPostDatas))
                    {
                        this.WebBrowser.Navigate(strUrl);
                    }
                    else
                    {
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(strPostDatas);
                        this.WebBrowser.Navigate(strUrl, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");
                    }

                    Syst.Log.WriteLog(Syst.Log.TYPE.Normal, "HTTP Request. URL: " + strUrl + (string.IsNullOrEmpty(strPostDatas) ? string.Empty : " (Post data : " + strPostDatas + ")"));
                }
            }
            else
            {
                this.OnUrlQueueEmpty?.Invoke();
            }
        }

        #region Private
        /// <summary>
        /// Called when the <see cref="WebBrowser"/> loaded the <see cref="WebServiceURL.WebServicesLoginURL"/> url.
        /// </summary>
        /// <param name="document">Html document of the login page</param>
        private void LoginPageLoaded(HtmlDocument document)
        {
            if (this.ConnectionState == 1)
            {
                Syst.Log.WriteLog(Syst.Log.TYPE.Error, "Authentification error. Invalid username or password");
                return;
            }

            Syst.Log.WriteLog(Syst.Log.TYPE.Normal, "Connection attempt. Username: " + Username);

            this.ConnectionState = 1;

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

        /// <summary>
        /// Called when the Main page of Gipsi is loaded
        /// </summary>
        /// <param name="document">Html document of the main page</param>
        private void MainPageLoaded(HtmlDocument document)
        {
            this.isLogged = true;
            this.OnMainPageLoaded?.Invoke(document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the array of the number of operations per hour is loaded.
        /// </summary>
        /// <param name="document">Html document who contain the array</param>
        private void NbOperationPerHourLoaded(HtmlDocument document)
        {
            this.OnNbOperationPerHourUpdated?.Invoke(document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the web page with the recent operations is loaded.
        /// </summary>
        /// <param name="document">Html document with the recent operations</param>
        private void OperationListLoaded(HtmlDocument document)
        {
            this.OnOperationListUpdated?.Invoke(document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the web page with the recent operations of the user's firehouse is loaded.
        /// </summary>
        /// <param name="document">Html document with the recent operations of the user's firehouse</param>
        private void OperationListOfUserFirehouseLoaded(HtmlDocument document)
        {
            this.OnOperationListOfUserFirehouseUpdated?.Invoke(document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the web page with the firefighter availabilities is loaded.
        /// </summary>
        /// <param name="document">Html document with the firefighter availabilities</param>
        private void FirefighterAvailabilitiesLoaded(HtmlDocument document)
        {
            this.OnListFirefighterAvailabilityUpdated?.Invoke(document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the number of operations in day is loaded.
        /// </summary>
        /// <param name="document">Html document with the number of operations</param>
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
                HtmlDocument document = this.WebBrowser.Document;

                this.webPageDuringLoading = false;

                TimeSpan responseTimeHttpRequest = TimeSpan.Zero;
                if (this.startedTimeHttpRequest != DateTime.MinValue)
                {
                    responseTimeHttpRequest = DateTime.Now - this.startedTimeHttpRequest;
                    this.startedTimeHttpRequest = DateTime.MinValue;
                }

                if (document == null)
                {
                    Syst.Log.WriteLog(Syst.Log.TYPE.Error, "HTTP error. No document");
                }
                else
                {
                    string log = "HTTP Request successfull. URL: " + document.Url.AbsoluteUri;
                    if (responseTimeHttpRequest != TimeSpan.Zero)
                    {
                        log += " (Response time: " + responseTimeHttpRequest.ToString(@"ss\.fff\s") + ")";
                    }

                    Syst.Log.WriteLog(Syst.Log.TYPE.Normal, log);

                    string urlWithoutQuery = document.Url.Scheme + "://" + document.Url.Host + document.Url.AbsolutePath;

                    if (urlWithoutQuery == WebServiceURL.WebServicesLoginURL.Url)
                    {
                        this.LoginPageLoaded(document);
                    }
                    else if (urlWithoutQuery == WebServiceURL.WebServiceMainPageURL.Url)
                    {
                        this.MainPageLoaded(document);
                    }
                    else if (urlWithoutQuery == WebServiceURL.WebServiceStatsForOperationPerHourURL.Url)
                    {
                        this.NbOperationPerHourLoaded(document);
                    }
                    else if (urlWithoutQuery == WebServiceURL.WebServiceOperationListURL.Url)
                    {
                        this.OperationListLoaded(document);
                    }
                    else if (urlWithoutQuery == WebServiceURL.WebServiceFirefighterAvailabilityURL.Url)
                    {
                        this.FirefighterAvailabilitiesLoaded(document);
                    }
                    else if (urlWithoutQuery == WebServiceURL.WebServiceNbOperationInDayURL.Url)
                    {
                        this.NbOperationInDayLoaded(document);
                    }
                    else if (urlWithoutQuery == WebServiceURL.WebServiceOperationListOfTheUserFirehouseURL.Url)
                    {
                        this.OperationListOfUserFirehouseLoaded(document);
                    }
                    else
                    {
                        Syst.Log.WriteLog(Syst.Log.TYPE.Error, "Web page unknown. URL: " + document.Url.AbsoluteUri);
                    }
                }
            }
            catch
            {
                Syst.Log.WriteLog(Syst.Log.TYPE.Error, "Error when processing the web page. URL: " + this.WebBrowser.Document.Url.AbsoluteUri);
            }
        }
        #endregion
    }
}
