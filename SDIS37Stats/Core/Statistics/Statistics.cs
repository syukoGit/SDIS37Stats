using System;
using System.Windows.Forms;

namespace SDIS37Stats.Core.Statistics
{
    class Statistics
    {
        private readonly Web.WebService webService;

        private readonly System.Globalization.CultureInfo dateTimeProvider = new System.Globalization.CultureInfo("fr-FR");
        private const string DateTimeFormat = "g";

        public delegate void OnStatUpdatedHandler();
        public OnStatUpdatedHandler OnStatUpdated;

        public Statistics(Web.WebService webService)
        {
            this.webService = webService;
            this.webService.OnHtmlDocStats += this.WebService_OnHtmlDocStats;
        }

        public int TotalOperationInDay { get; private set; }

        public DateTime LastRefresh { get; private set; }

        public int[] OperationPerHour { get; private set; } = new int[23];
        
        #region Event
        private void WebService_OnHtmlDocStats(HtmlDocument htmlDocument)
        {
            string dateTimeStr = htmlDocument.GetElementById("date").InnerText + " " + htmlDocument.GetElementById("last_refresh").InnerText;

            this.TotalOperationInDay = int.Parse(htmlDocument.GetElementById("number-interventions").InnerText);
            this.LastRefresh = DateTime.ParseExact(dateTimeStr, DateTimeFormat, this.dateTimeProvider);

            this.OnStatUpdated?.Invoke();
        }
        #endregion
    }
}
