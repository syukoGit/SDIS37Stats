﻿namespace SDIS37Stats.Core.Web
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class managing a connection with the GipsiWeb webservice of the SDIS37.
    /// </summary>
    /// <remarks>
    /// It uses a <see cref="System.Windows.Forms.WebBrowser"/> so objects can disposable.
    /// </remarks>
    class WebService : IDisposable
    {
        /// <summary>
        /// Const string used for get the login url of the webservice.
        /// </summary>
        public const string WebServicesLoginURL = "https://webservices.sdis37.fr/users/login";

        /// <summary>
        /// Const string used for get the statistics url (main page) of the webservice.
        /// </summary>
        public const string WebServicesStatsURL = "https://webservices.sdis37.fr/interventions";

        /// <summary>
        /// Private string for save the username used for connection.
        /// </summary>
        private string username;

        /// <summary>
        /// Private string for save the password used for connection.
        /// </summary>
        private string password;

        /// <summary>
        /// Private integer for get and set a connection state.
        /// </summary>
        /// <remarks>
        /// 0 : no connection.
        /// 1 : attempt connection.
        /// 2 : connection success.
        /// </remarks>
        private int connectionState = 0;

        public delegate void OnHtmlDocStatsHandler(HtmlDocument htmlDocument);
        public event OnHtmlDocStatsHandler OnHtmlDocStats;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebService" /> class.
        /// </summary>
        /// <param name="username">username used for connection</param>
        /// <param name="password">password used for connection</param>
        public WebService(string username, string password)
        {
            this.username = username;
            this.password = password;

            this.WebBrowser = new WebBrowser();

            this.WebBrowser.DocumentCompleted += this.WebBrowser_DocumentCompleted;

            this.WebBrowser.Url = new Uri(WebServicesLoginURL);
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
        /// Refresh the <see cref="System.Windows.Forms.WebBrowser"/>.
        /// </summary>
        public void Refresh()
        {
            Console.Out.WriteLine("Refresh");
            this.WebBrowser.Url = new Uri(WebServicesStatsURL);
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

                    if (string.IsNullOrEmpty(this.username) || string.IsNullOrEmpty(this.password))
                    {
                        var getCredentials = new Controls.GetCredentials();
                        _ = getCredentials.ShowDialog();

                        var (Username, Password) = getCredentials.Credentials;
                        this.username = Username;
                        this.password = Password;
                    }

                    HtmlDocument document = WebBrowser.Document;

                    if (document != null)
                    {
                        document.All["username"].SetAttribute("value", this.username);
                        document.All["password"].SetAttribute("value", this.password);

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

                    if (document != null && document.Title == "Sdis37 Gipsiweb")
                    {
                        this.OnHtmlDocStats?.Invoke(WebBrowser.Document);
                    }
                    else
                    {
                        Console.Out.WriteLine("Page inconnue");
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
