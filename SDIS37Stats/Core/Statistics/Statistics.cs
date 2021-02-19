namespace SDIS37Stats.Core.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    class Statistics
    {
        private readonly Web.WebService webService;

        private static readonly System.Globalization.CultureInfo DateTimeProvider = new System.Globalization.CultureInfo("fr-FR");
        private const string DateTimeFormat = "g";

        private string firehouseName = string.Empty;

        private int totalOperationInDay = 0;

        private DateTime lastRefreshDateTimeLocal;

        private List<int> operationPerHour;

        private Dictionary<int, Operation> recentOperationList;

        private List<Operation> recentOperationOfUserFirehouse;

        private List<FirefighterAvailability> firefighterAvailabilities;

        #region EventHandler
        public delegate void OnNewOperationHandler();
        public event OnNewOperationHandler OnNewOperation;

        public delegate void OnFirehouseNameUpdatedHandler(string firehouseName);
        public event OnFirehouseNameUpdatedHandler OnFirehouseNameUpdated;

        public delegate void OnTotalOperationInDayUpdatedHandler(int totalOperationInDay);
        public event OnTotalOperationInDayUpdatedHandler OnTotalOperationInDayUpdated;

        public delegate void OnLastRefreshDateTimeLocalUpdatedHandler(DateTime lastRefreshDateTimeLocal);
        public event OnLastRefreshDateTimeLocalUpdatedHandler OnLastRefreshDateTimeLocalUpdated;

        public delegate void OnOperationPerHourUpdatedHandler(List<int> operationPerHour);
        public event OnOperationPerHourUpdatedHandler OnOperationPerHourUpdated;

        public delegate void OnRecentOperationListUpdatedHandler(Dictionary<int, Operation> recentOperationList);
        public event OnRecentOperationListUpdatedHandler OnRecentOperationListUpdated;

        public delegate void OnRecentOperationOfUserFirehouseUpdatedHandler(List<Operation> recentOperationOfUserFirehouse);
        public event OnRecentOperationOfUserFirehouseUpdatedHandler OnRecentOperationOfUserFirehouseUpdated;

        public delegate void OnFirefighterAvailabilitiesUpdatedHandler(List<FirefighterAvailability> firefighterAvailabilities);
        public event OnFirefighterAvailabilitiesUpdatedHandler OnFirefighterAvailabilitiesUpdated;
        #endregion

        public Statistics(Web.WebService webService)
        {
            this.webService = webService;
            this.webService.OnMainPageLoaded += this.WebService_MainPage;
            this.webService.OnNbOperationInDayUpdated += this.WebService_OnNbOperationInDayUpdated;
            this.webService.OnNbOperationPerHourUpdated += this.WebService_NbOperationPerHour;
            this.webService.OnRecentOperationListUpdated += this.WebService_RecentOperationList;
            this.webService.OnListFirefighterAvailabilityUpdated += this.WebService_FirefighterAvailabilityList;
        }

        #region Property
        public string FirehouseName
        {
            get
            {
                return this.firehouseName;
            }
            private set
            {
                this.firehouseName = value;
                this.OnFirehouseNameUpdated?.Invoke(this.firehouseName);
            }
        }

        public int TotalOperationInDay
        {
            get
            {
                return this.totalOperationInDay;
            }
            private set
            {
                this.totalOperationInDay = value;
                this.OnTotalOperationInDayUpdated?.Invoke(this.totalOperationInDay);
            }
        }

        public DateTime LastRefreshDateTimeLocal
        {
            get
            {
                return this.lastRefreshDateTimeLocal;
            }
            private set
            {
                this.lastRefreshDateTimeLocal = value;
                this.OnLastRefreshDateTimeLocalUpdated?.Invoke(this.lastRefreshDateTimeLocal);
            }
        }
        
        public List<int> OperationPerHour
        {
            get
            {
                return this.operationPerHour;
            }
            private set
            {
                this.operationPerHour = value;
                this.OnOperationPerHourUpdated?.Invoke(this.operationPerHour);
            }
        }

        public Dictionary<int, Operation> RecentOperationList
        {
            get
            {
                return this.recentOperationList;
            }
            private set
            {
                this.recentOperationList = value;
                this.OnRecentOperationListUpdated?.Invoke(this.recentOperationList);
            }
        }

        public List<Operation> RecentOperationOfUserFirehouse
        {
            get
            {
                return this.recentOperationOfUserFirehouse;
            }
            private set
            {
                this.recentOperationOfUserFirehouse = value;
                this.OnRecentOperationOfUserFirehouseUpdated?.Invoke(this.recentOperationOfUserFirehouse);
            }
        }

        public List<FirefighterAvailability> FirefighterAvailabilities
        {
            get
            {
                return this.firefighterAvailabilities;
            }
            private set
            {
                this.firefighterAvailabilities = value;
                this.OnFirefighterAvailabilitiesUpdated?.Invoke(this.firefighterAvailabilities);
            }
        }
        #endregion

        #region Private
        private void UpdateOperation(Dictionary<int, Operation> operationList, Operation operationUpdated)
        {
            var operation = operationList.Where(c => operationUpdated.NumOperation == c.Key).Select(c => c.Value).ToList()[0];

            operation.Localisation = operationUpdated.Localisation;
            operation.OperationDescription = operationUpdated.OperationDescription;
            operation.Time = operationUpdated.Time;
            operation.Type = operationUpdated.Type;
            operation.VehiculeEnrolled = operationUpdated.VehiculeEnrolled;
        }
        #endregion

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

            this.LastRefreshDateTimeLocal = DateTime.ParseExact(dateTimeStr, DateTimeFormat, DateTimeProvider);

            this.webService.RefreshAllValue();
        }

        private void WebService_OnNbOperationInDayUpdated(HtmlDocument htmlDocument)
        {
            this.TotalOperationInDay = int.Parse(htmlDocument.Body.InnerHtml.ToString());
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

            bool newOperation = false;
            var newList = this.RecentOperationList != null ? new Dictionary<int, Operation>(this.RecentOperationList) : new Dictionary<int, Operation>();

            foreach (HtmlElement item in list)
            {
                var operation = HtmlElementToOperation(item);

                if (newList.Where(c => c.Key == operation.NumOperation).Count() > 0)
                {
                    this.UpdateOperation(newList, operation);
                }
                else
                {
                    newList.Add(operation.NumOperation, operation);
                    newOperation = true;
                }
            }

            this.RecentOperationList = newList;
            this.RecentOperationOfUserFirehouse = newList.Where(c => c.Value.VehiculeEnrolled.Where(t => t.Contains(this.FirehouseName)).Count() > 0).Select(c => c.Value).ToList();
                
            if (newOperation)
            {
                this.OnNewOperation?.Invoke();
            }
        }

        private void WebService_FirefighterAvailabilityList(HtmlDocument htmlDocument)
        {
            var data = htmlDocument.GetElementById("liste-dipo");
            data = data.GetElementsByTagName("tbody")[0];
            var firefighterList = data.GetElementsByTagName("tr");

            this.FirefighterAvailabilities?.Clear();

            var newList = new List<FirefighterAvailability>();

            foreach (HtmlElement firefighter in firefighterList)
            {
                var content = firefighter.GetElementsByTagName("td");

                FirefighterAvailability.AVAILABILITY availability;
                if (content[0].InnerText.Contains("Disponible sur place"))
                {
                    availability = FirefighterAvailability.AVAILABILITY.AvailableOnSite;
                }
                else if (content[0].InnerText.Contains("Disponible 5 min"))
                {
                    availability = FirefighterAvailability.AVAILABILITY.Available5Min;
                }
                else if (content[0].InnerText.Contains("Disponible 10 min"))
                {
                    availability = FirefighterAvailability.AVAILABILITY.Available10Min;
                }
                else if (content[0].InnerText.Contains("En intervention"))
                {
                    availability = FirefighterAvailability.AVAILABILITY.InIntervention;
                }
                else
                {
                    availability = FirefighterAvailability.AVAILABILITY.NotAvailable;
                }

                string matricule = content[1].InnerText;
                string name = content[2].InnerText;
                string rank = content[3].InnerText;

                newList.Add(new FirefighterAvailability
                {
                    Availability = availability,
                    Matricule = matricule,
                    Name = name,
                    Rank = rank
                });
            }

            this.FirefighterAvailabilities = newList;
        }
        #endregion

        #region Static
        private static Operation HtmlElementToOperation(HtmlElement item)
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

            return new Operation
            {
                Time = time,
                NumOperation = numOperation,
                Type = type,
                Localisation = localisation,
                OperationDescription = operationDescription,
                VehiculeEnrolled = vehiculeEnrolled
            };
        }
        #endregion
    }
}
