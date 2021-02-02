using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SDIS37Stats.Core.Statistics
{
    class Statistics
    {
        private readonly Web.WebService webService;

        private static readonly System.Globalization.CultureInfo DateTimeProvider = new System.Globalization.CultureInfo("fr-FR");
        private const string DateTimeFormat = "g";

        public delegate void OnStatUpdatedHandler();
        public OnStatUpdatedHandler OnStatUpdated;

        public Statistics(Web.WebService webService)
        {
            this.webService = webService;
            this.webService.OnNbOperationTodayUpdated += this.WebService_MainPage;
            this.webService.OnNbOperationPerHourUpdated += this.WebService_NbOperationPerHour;
            this.webService.OnRecentOperationListUpdated += this.WebService_RecentOperationList;
        }

        public string FirehouseName { get; set; } = null;

        public int TotalOperationInDay { get; private set; }

        public DateTime LastRefresh { get; private set; }

        public List<int> OperationPerHour { get; private set; } = new List<int>();

        public List<Operation> RecentOperationList { get; set; } = new List<Operation>();

        #region Event
        private void WebService_MainPage(HtmlDocument htmlDocument)
        {
            string dateTimeStr = htmlDocument.GetElementById("date").InnerText + " " + htmlDocument.GetElementById("last_refresh").InnerText;

            if (string.IsNullOrWhiteSpace(this.FirehouseName))
            {
                foreach (HtmlElement item in htmlDocument.GetElementsByTagName("a"))
                {
                    if (item.OuterHtml.Contains("<a class=\"user-profile dropdown-toggle\" aria-expanded=\"false\" href=\"javascript:;\" data-toggle=\"dropdown\">"))
                    {
                        string str = Regex.Replace(item.OuterText, @"[a-zA-Z0-9 ]*\(", string.Empty);
                        this.FirehouseName = Regex.Replace(str, @"\)[a-zA-Z0-9 ]*", string.Empty);
                    }
                }
            }

            this.TotalOperationInDay = int.Parse(htmlDocument.GetElementById("number-interventions").InnerText);
            this.LastRefresh = DateTime.ParseExact(dateTimeStr, DateTimeFormat, DateTimeProvider);
        }

        private void WebService_NbOperationPerHour(HtmlDocument htmlDocument)
        {
            string data = htmlDocument.Body.InnerHtml;
            data = data.Replace("[", string.Empty).Replace("]", string.Empty);
            this.OperationPerHour = data.Split(',').Select(c => int.Parse(c)).ToList();
        }

        private void WebService_RecentOperationList(HtmlDocument htmlDocument)
        {
            var data = htmlDocument.GetElementsByTagName("tbody")[0];
            var list = data.GetElementsByTagName("tr");

            this.RecentOperationList.Clear();

            foreach (HtmlElement item in list)
            {
                DateTime time = DateTime.ParseExact(item.Children[0].InnerHtml, "HH:mm", DateTimeProvider);
                int numOperation = int.Parse(item.Children[1].InnerText);
                string localisation = item.Children[2].GetElementsByTagName("b")[0].InnerHtml;
                string operationDescription = item.Children[2].Children[1].InnerText;

                Operation.OperationType type = Operation.OperationType.OTHER;
                if (item.Children[1].InnerHtml.Contains("/img/sap.gif"))
                {
                    type = Operation.OperationType.SAP;
                }
                else if (item.Children[1].InnerHtml.Contains("img/inc.gif"))
                {
                    type = Operation.OperationType.INC;
                }
                else if (item.Children[1].InnerHtml.Contains("img/od.gif"))
                {
                    type = Operation.OperationType.OD;
                }

                HashSet<string> vehiculeEnrolled = new HashSet<string>();
                foreach (HtmlElement vehicule in item.Children[3].GetElementsByTagName("div"))
                {
                    vehiculeEnrolled.Add(vehicule.InnerText);
                }

                this.RecentOperationList.Add(new Operation
                {
                    Time = time,
                    NumOperation = numOperation,
                    Type = type,
                    Localisation = localisation,
                    OperationDescription = operationDescription,
                    VehiculeEnrolled = vehiculeEnrolled
                });
            }

            this.OnStatUpdated?.Invoke();
        }
        #endregion
    }
}
