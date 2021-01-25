using System;
using System.Collections.Generic;
using System.Linq;
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
            this.webService.OnNbOperationTodayUpdated += this.WebService_MainPage;
            this.webService.OnNbOperationPerHourUpdated += this.WebService_NbOperationPerHour;
        }

        public int TotalOperationInDay { get; private set; }

        public DateTime LastRefresh { get; private set; }

        public List<int> OperationPerHour { get; private set; } = new List<int>();
        
        #region Event
        private void WebService_MainPage(HtmlDocument htmlDocument)
        {
            string dateTimeStr = htmlDocument.GetElementById("date").InnerText + " " + htmlDocument.GetElementById("last_refresh").InnerText;

            this.TotalOperationInDay = int.Parse(htmlDocument.GetElementById("number-interventions").InnerText);
            this.LastRefresh = DateTime.ParseExact(dateTimeStr, DateTimeFormat, this.dateTimeProvider);
        }

        private void WebService_NbOperationPerHour(HtmlDocument htmlDocument)
        {
            string data = htmlDocument.Body.InnerHtml;
            data = data.Replace("[", string.Empty).Replace("]", string.Empty);
            this.OperationPerHour = data.Split(',').Select(c => int.Parse(c)).ToList();

            this.OnStatUpdated?.Invoke();
        }
        #endregion
    }
}
