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

        private static readonly System.Globalization.CultureInfo DateTimeProvider = new("fr-FR");

        private string firehouseName = string.Empty;

        private List<FirefighterAvailability> firefighterAvailabilities;

        private bool initializationInProgress = true;

        private readonly Dictionary<int, Operation> operationDictionary = new();

        #region EventHandler
        public delegate void OnNewOperationHandler();
        public event OnNewOperationHandler OnNewOperation;

        public delegate void OnFirehouseNameUpdatedHandler(string firehouseName);
        public event OnFirehouseNameUpdatedHandler OnFirehouseNameUpdated;

        public delegate void OnTotalOperationInDayUpdatedHandler(int totalOperationInDay);
        public event OnTotalOperationInDayUpdatedHandler OnTotalOperationInDayUpdated;

        public delegate void OnOperationPerHourUpdatedHandler(List<int> operationPerHour);
        public event OnOperationPerHourUpdatedHandler OnOperationPerHourUpdated;

        public delegate void OnOperationListUpdatedHandler(List<Operation> operationList);
        public event OnOperationListUpdatedHandler OnOperationListUpdated;

        public delegate void OnOperationOfUserFirehouseUpdatedHandler(List<Operation> operationListOfUserFirehouse);
        public event OnOperationOfUserFirehouseUpdatedHandler OnOperationListOfUserFirehouseUpdated;

        public delegate void OnFirefighterAvailabilitiesUpdatedHandler(List<FirefighterAvailability> firefighterAvailabilities);
        public event OnFirefighterAvailabilitiesUpdatedHandler OnFirefighterAvailabilitiesUpdated;
        #endregion

        public Statistics(Web.WebService webService)
        {
            this.webService = webService;

            this.Init();

            this.webService.OnMainPageLoaded += this.WebService_MainPage;
            this.webService.OnOperationListUpdated += this.WebService_OperationList;
            this.webService.OnListFirefighterAvailabilityUpdated += this.WebService_FirefighterAvailabilityList;
            this.webService.OnOperationListOfUserFirehouseUpdated += this.WebService_OperationList;
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

        public int TotalOperationToday => this.operationDictionary.Where(c => c.Value.Time.Date == DateTime.Now.Date).Count();

        public int[] OperationPerHourToday
        {
            get
            {
                var operationListToday = this.operationDictionary.Values.Where(c => c.Time.Date == DateTime.Now.Date);

                var operationPerHour = operationListToday.GroupBy(c => c.Time.Hour, c => c.Time, (hour, times) => (Hour: hour, Count: times.Count())).ToArray();
                Array.Sort(operationPerHour, (x, y) => x.Hour.CompareTo(y.Hour));

                int[] operationPerHourArray = new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                foreach (var (Hour, Count) in operationPerHour)
                {
                    operationPerHourArray[Hour] = Count;
                }

                return operationPerHourArray;
            }
        }

        public List<Operation> OperationList => this.operationDictionary.Select(c => c.Value).ToList();

        public List<Operation> OperationListOfUserFirehouse => this.operationDictionary.Select(c => c.Value).Where(c => c.VehiculeEnrolled.Any(t => t.Contains(this.FirehouseName))).ToList();

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

        #region Public
        public void Refresh()
        {
            this.webService.UrlQueue.Enqueue((Web.WebServiceURL.WebServiceOperationListURL, null, null));
            this.webService.UrlQueue.Enqueue((Web.WebServiceURL.WebServiceFirefighterAvailabilityURL, null, null));
            this.webService.NavigateToNextUrl();
        }
        #endregion

        #region Private
        private void Init()
        {
            this.webService.UrlQueue.Enqueue((Web.WebServiceURL.WebServiceOperationListURL, null, null));
            this.webService.UrlQueue.Enqueue((Web.WebServiceURL.WebServiceFirefighterAvailabilityURL, null, null));
            this.webService.UrlQueue.Enqueue((Web.WebServiceURL.WebServiceOperationListOfTheUserFirehouseURL, null, null));
            this.webService.OnOperationListUpdated += this.WebService_OperationList_Init;
            this.webService.NavigateToNextUrl();
        }

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
        private void WebService_OperationList_Init(HtmlDocument htmlDocument)
        {
            try
            {
                var paginator = htmlDocument.GetElementsByTagName("li").Cast<HtmlElement>();

                int currentPage;
                if (paginator.Where(c => c.OuterHtml.Contains("class=active")).Any())
                {
                    currentPage = int.Parse(paginator.Where(c => c.OuterHtml.Contains("class=active")).First().InnerText);
                }
                else
                {
                    currentPage = 1;
                }

                bool isLastPage = !paginator.Where(c => c.OuterHtml.Contains("class=last")).Any();

                if (isLastPage)
                {
                    this.webService.OnOperationListUpdated -= this.WebService_OperationList_Init;
                    this.initializationInProgress = false;
                }
                else
                {
                    this.webService.UrlQueue.Enqueue((Web.WebServiceURL.WebServiceOperationListURL, new Dictionary<string, string> { { "page", (currentPage + 1).ToString() } }, null));
                    this.webService.NavigateToNextUrl();
                }
            }
            catch (Exception e)
            {
                Syst.Log.WriteLog(Syst.Log.TYPE.Error, "Error. " + e.Message);
            }
        }

        private void WebService_MainPage(HtmlDocument htmlDocument)
        {
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
        }

        private void WebService_OperationList(HtmlDocument htmlDocument)
        {
            var data = htmlDocument.GetElementsByTagName("tbody")[0];
            var list = data.GetElementsByTagName("tr");

            var newOperationList = new List<Operation>();
            var updatedOperationList = new List<Operation>();

            foreach (HtmlElement item in list)
            {
                var operation = Statistics.HtmlElementToOperation(item);

                if (this.operationDictionary.ContainsKey(operation.NumOperation))
                {
                    this.UpdateOperation(this.operationDictionary, operation);
                    updatedOperationList.Add(operation);
                }
                else
                {
                    this.operationDictionary.Add(operation.NumOperation, operation);
                    newOperationList.Add(operation);
                }
            }

            this.OnTotalOperationInDayUpdated?.Invoke(this.TotalOperationToday);
            this.OnOperationPerHourUpdated?.Invoke(this.OperationPerHourToday.ToList());
            this.OnOperationListUpdated?.Invoke(this.OperationList);
            this.OnOperationListOfUserFirehouseUpdated?.Invoke(this.OperationListOfUserFirehouse);

            if (newOperationList.Any() && !this.initializationInProgress)
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
            string dateTimePatern;
            if (Regex.IsMatch(item.Children[0].InnerHtml, @"^[0-2]{0,1}[0-9]:[0-5]{0,1}[0-9]$"))
            {
                dateTimePatern = "HH:mm";
            }
            else
            {
                dateTimePatern = "dd/MM/yy HH:mm";
            }

            DateTime time = DateTime.ParseExact(item.Children[0].InnerHtml, dateTimePatern, DateTimeProvider);
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

            HashSet<string> vehiculeEnrolled = new();
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
