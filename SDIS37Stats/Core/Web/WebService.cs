// -----------------------------------------------------------------------
// <copyright file="WebService.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
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
    public class WebService : IDisposable
    {
        /// <summary>
        /// Started date and time to http request is send.
        /// Used for measure the response time of the last http request.
        /// </summary>
        private DateTime startedTimeHttpRequest = DateTime.MinValue;

        /// <summary>
        /// A value indicating whether a web page is during loading.
        /// </summary>
        private bool webPageDuringLoading = false;

        /// <summary>
        /// A value indicating whether a web service is logged to the SDIS37 web site.
        /// </summary>
        private bool isLogged = false;

        /// <summary>
        /// A <see cref="EState"/> value indicating the state os the web service.
        /// </summary>
        private EState state = EState.NotStated;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebService" /> class.
        /// </summary>
        public WebService()
        {
            this.WebBrowser = new WebBrowser();

            this.WebBrowser.DocumentCompleted += this.WebBrowser_DocumentCompleted;
            this.WebBrowser.Navigating += this.WebBrowser_Navigating;

            this.WebBrowser.Url = new Uri(WebServiceURL.WebServiceMainPageURL.GetAbsoluteUrl(null));
        }

        /// <summary>
        /// Represents the method that will handle the events when the <see cref="HtmlDocument"/> is loaded of the <see cref="WebService"/> class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="htmlDocument">A <see cref="HtmlDocument"/> that is loaded.</param>
        public delegate void HtmlDocumentLoadedEventHandler(object sender, HtmlDocument htmlDocument);

        /// <summary>
        /// Represents the method that will handle the <see cref="UrlQueueEmpty"/> event of the <see cref="WebService"/> class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains no data.</param>
        public delegate void UrlQueueEmptyEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Represents the method that will handle the <see cref="StateChanged"/> event of the <see cref="WebService"/> class.
        /// </summary>
        /// <param name="e">The source of the event.</param>
        /// <param name="state">The new <see cref="EState"/> of the <see cref="WebService"/>.</param>
        public delegate void StateChangedEventHandler(object e, EState state);

        /// <summary>
        /// Occurs when the html of the main page of the SDIS37 web site is loaded.
        /// </summary>
        public event HtmlDocumentLoadedEventHandler MainPageHtmlLoaded;

        /// <summary>
        /// Occurs when the html that helps to recover the number of operation is loaded.
        /// </summary>
        public event HtmlDocumentLoadedEventHandler NbOperationPageHtmlLoaded;

        /// <summary>
        /// Occurs when the html that helps to recover the number of operation per hour is loaded.
        /// </summary>
        public event HtmlDocumentLoadedEventHandler NbOperationPerHourPageHtmlLoaded;

        /// <summary>
        /// Occurs when the html that helps to recover the operation of the department is loaded.
        /// </summary>
        public event HtmlDocumentLoadedEventHandler OperationListPageHtmlLoaded;

        /// <summary>
        /// Occurs when the html that helps to recover the operation of the user's firehouse is loaded.
        /// </summary>
        public event HtmlDocumentLoadedEventHandler OperationListOfUserFirehousePageHtmlLoaded;

        /// <summary>
        /// Occurs when the html that helps to recover the operation of the firefighters' availabilities is loaded.
        /// </summary>
        public event HtmlDocumentLoadedEventHandler ListFirefighterAvailabilitiesPageHtmlLoaded;

        /// <summary>
        /// Occurs when the url queue is empty.
        /// </summary>
        public event UrlQueueEmptyEventHandler UrlQueueEmpty;

        /// <summary>
        /// Occurs when the state of the <see cref="WebService"/> is changed.
        /// </summary>
        public event StateChangedEventHandler StateChanged;

        /// <summary>
        /// Defines the state of the <see cref="WebService"/> instance.
        /// </summary>
        public enum EState
        {
            /// <summary>
            /// The <see cref="WebService"/> is not started.
            /// </summary>
            NotStated,

            /// <summary>
            /// The <see cref="WebService"/> is loading a web page.
            /// </summary>
            DataRetrieving,

            /// <summary>
            /// The <see cref="WebService"/> is up to date.
            /// </summary>
            UpToDate,

            /// <summary>
            /// The <see cref="WebService"/> is waiting of connection.
            /// </summary>
            AttemptConnection,

            /// <summary>
            /// The connection to the web page is failed.
            /// </summary>
            FailedConnection,

            /// <summary>
            /// The software has not available network.
            /// </summary>
            NoConnection,

            /// <summary>
            /// The <see cref="WebService"/> is in the error state.
            /// </summary>
            Error,
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
        /// Gets the state of the <see cref="WebService"/>.
        /// </summary>
        public EState State
        {
            get
            {
                return this.state;
            }

            private set
            {
                this.state = value;
                this.StateChanged?.Invoke(this, this.state);
            }
        }

        /// <summary>
        /// Gets the currently processed url.
        /// </summary>
        public string CurrentUrl => this.WebBrowser.Url.Scheme + "://" + this.WebBrowser.Url.Host + this.WebBrowser.Url.AbsolutePath;

        /// <summary>
        /// Gets the <see cref="System.Windows.Forms.WebBrowser"/> used for connection.
        /// </summary>
        public WebBrowser WebBrowser { get; private set; }

        /// <summary>
        /// Gets the current url queue.
        /// </summary>
        public Queue<(URL url, Dictionary<string, string> queryParams, Dictionary<string, string> postDatas)> UrlQueue { get; } = new ();

        /// <summary>
        /// Dispose all objects disposable.
        /// </summary>
        public void Dispose()
        {
            this.WebBrowser?.Dispose();
            this.WebBrowser = null;

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Clear session by deleting the authentication cache.
        /// </summary>
        public void ClearSession()
        {
            Syst.Log.WriteLog(Syst.Log.EType.Normal, "WebService -> Clear authentification cache");
            this.WebBrowser.Document.ExecCommand("ClearAuthenticationCache", false, null);
            this.UrlQueue.Enqueue((WebServiceURL.WebServicesLoginURL, null, null));

            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Sets the next url of the queue to <see cref="WebBrowser"/>.
        /// </summary>
        public void NavigateToNextUrl()
        {
            if (this.UrlQueue.Count > 0)
            {
                if (!this.webPageDuringLoading)
                {
                    this.webPageDuringLoading = true;

                    if (this.isLogged)
                    {
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

                        Syst.Log.WriteLog(Syst.Log.EType.Normal, "HTTP Request. URL: " + strUrl + (string.IsNullOrEmpty(strPostDatas) ? string.Empty : " (Post data : " + strPostDatas + ")"));
                    }
                    else
                    {
                        this.WebBrowser.ScriptErrorsSuppressed = true;
                        this.WebBrowser.Navigate(WebServiceURL.WebServicesLoginURL.Url);
                    }
                }
            }
            else
            {
                this.State = EState.UpToDate;
                this.UrlQueueEmpty?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when the <see cref="WebBrowser"/> loaded the <see cref="WebServiceURL.WebServicesLoginURL"/> url.
        /// </summary>
        /// <param name="document">Html document of the login page.</param>
        private void LoginPageLoaded(HtmlDocument document)
        {
            if (document.Body.InnerHtml.Contains("div class=\"alert alert-danger\" role=\"alert\""))
            {
                Syst.Log.WriteLog(Syst.Log.EType.Error, "Authentification error. Invalid username or password");
                this.State = EState.FailedConnection;
                Username = string.Empty;
                Password = string.Empty;
                return;
            }

            this.State = EState.AttemptConnection;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                var getCredentials = new Controls.GetCredentials();
                _ = getCredentials.ShowDialog();

                var (username, password) = getCredentials.Credentials;
                WebService.Username = username;
                WebService.Password = password;
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

                _ = buttonElem?.InvokeMember("click");
            }

            Syst.Log.WriteLog(Syst.Log.EType.Normal, "Connection attempt. Username: " + Username);
        }

        /// <summary>
        /// Called when the Main page of Gipsi is loaded.
        /// </summary>
        /// <param name="document">Html document of the main page.</param>
        private void MainPageLoaded(HtmlDocument document)
        {
            this.isLogged = true;
            this.MainPageHtmlLoaded?.Invoke(this, document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the array of the number of operations per hour is loaded.
        /// </summary>
        /// <param name="document">Html document who contain the array.</param>
        private void NbOperationPerHourLoaded(HtmlDocument document)
        {
            this.NbOperationPerHourPageHtmlLoaded?.Invoke(this, document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the web page with the recent operations is loaded.
        /// </summary>
        /// <param name="document">Html document with the recent operations.</param>
        private void OperationListLoaded(HtmlDocument document)
        {
            this.OperationListPageHtmlLoaded?.Invoke(this, document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the web page with the recent operations of the user's firehouse is loaded.
        /// </summary>
        /// <param name="document">Html document with the recent operations of the user's firehouse.</param>
        private void OperationListOfUserFirehouseLoaded(HtmlDocument document)
        {
            this.OperationListOfUserFirehousePageHtmlLoaded?.Invoke(this, document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the web page with the firefighter availabilities is loaded.
        /// </summary>
        /// <param name="document">Html document with the firefighter availabilities.</param>
        private void FirefighterAvailabilitiesLoaded(HtmlDocument document)
        {
            this.ListFirefighterAvailabilitiesPageHtmlLoaded?.Invoke(this, document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the number of operations in day is loaded.
        /// </summary>
        /// <param name="document">Html document with the number of operations.</param>
        private void NbOperationPageLoaded(HtmlDocument document)
        {
            this.NbOperationPageHtmlLoaded?.Invoke(this, document);
            this.NavigateToNextUrl();
        }

        /// <summary>
        /// Event called when the document is load by the <see cref="System.Windows.Forms.WebBrowser"/>.
        /// </summary>
        /// <param name="sender">Object who send the event.</param>
        /// <param name="e">Event's arguments.</param>
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
                    Syst.Log.WriteLog(Syst.Log.EType.Error, "HTTP error. No document");
                }
                else
                {
                    string log = "HTTP Request successfull. URL: " + document.Url.AbsoluteUri;
                    if (responseTimeHttpRequest != TimeSpan.Zero)
                    {
                        log += " (Response time: " + responseTimeHttpRequest.ToString(@"ss\.fff\s") + ")";
                    }

                    Syst.Log.WriteLog(Syst.Log.EType.Normal, log);

                    string urlWithoutQuery = document.Url.Scheme + "://" + document.Url.Host + document.Url.AbsolutePath;

                    if (urlWithoutQuery == "res://ieframe.dll/navcancl.htm")
                    {
                        if (Syst.Network.IsNetworkAvailable())
                        {
                            this.State = EState.Error;
                            Syst.Log.WriteLog(Syst.Log.EType.Error, "Error");
                        }
                        else
                        {
                            Syst.Log.WriteLog(Syst.Log.EType.Error, "No connection");

                            this.UrlQueue.Clear();
                            this.NavigateToNextUrl();

                            this.State = EState.NoConnection;
                        }
                    }
                    else if (urlWithoutQuery == WebServiceURL.WebServicesLoginURL.Url)
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
                        this.NbOperationPageLoaded(document);
                    }
                    else if (urlWithoutQuery == WebServiceURL.WebServiceOperationListOfTheUserFirehouseURL.Url)
                    {
                        this.OperationListOfUserFirehouseLoaded(document);
                    }
                    else
                    {
                        Syst.Log.WriteLog(Syst.Log.EType.Error, "Web page unknown. URL: " + document.Url.AbsoluteUri);
                    }
                }
            }
            catch
            {
                Syst.Log.WriteLog(Syst.Log.EType.Error, "Error when processing the web page. URL: " + this.WebBrowser.Document.Url.AbsoluteUri);
            }
        }

        /// <summary>
        /// Occurs before the <see cref="WebBrowser"/> control navigates to a new document.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="WebBrowserNavigatingEventArgs"/> that contains the event data.</param>
        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.Scheme + "://" + e.Url.Host + e.Url.AbsolutePath;
            if (url == WebServiceURL.WebServicesLoginURL.Url)
            {
                this.State = EState.AttemptConnection;
            }
            else if (url == "res://ieframe.dll/navcancl.htm")
            {
                if (Syst.Network.IsNetworkAvailable())
                {
                    this.State = EState.Error;
                    Syst.Log.WriteLog(Syst.Log.EType.Error, "Error");
                }
                else
                {
                    Syst.Log.WriteLog(Syst.Log.EType.Error, "No connection");

                    this.UrlQueue.Clear();

                    this.State = EState.NoConnection;
                }
            }
            else
            {
                this.State = EState.DataRetrieving;
            }
        }
    }
}
