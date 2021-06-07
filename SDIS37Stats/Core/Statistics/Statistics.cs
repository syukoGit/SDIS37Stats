// -----------------------------------------------------------------------
// <copyright file="Statistics.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    /// <summary>
    /// Class fo make the statistics with the firefighter's operations.
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Used for parse string to <see cref="DateTime"/>.
        /// </summary>
        private static readonly System.Globalization.CultureInfo DateTimeProvider = new ("fr-FR");

        /// <summary>
        /// Path where the statistics are saved.
        /// </summary>
        private static readonly string StatisticsFolderForSave = @"StatisticsSave\";

        /// <summary>
        /// Used for communicate to the site.
        /// </summary>
        private readonly Web.WebService webService;

        /// <summary>
        /// <see cref="Directory"/> used to get a <see cref="Operation"/> by the id.
        /// The key is a <see cref="int"/> and the value is a <see cref="Operation"/>.
        /// </summary>
        private readonly Dictionary<int, Operation> operationDictionary = new ();

        /// <summary>
        /// The firehouse name of the user.
        /// </summary>
        private string firehouseName = string.Empty;

        /// <summary>
        /// List of <see cref="FirefighterAvailability"/> of the user's firehouse.
        /// </summary>
        private List<FirefighterAvailability> firefighterAvailabilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="Statistics"/> class.
        /// </summary>
        /// <param name="webService">A <see cref="Web.WebService"/> used for retrieve the data.</param>
        public Statistics(Web.WebService webService)
        {
            this.webService = webService;

            this.Init();

            this.webService.MainPageHtmlLoaded += this.WebService_MainPage;
            this.webService.OperationListPageHtmlLoaded += this.WebService_OperationList;
            this.webService.ListFirefighterAvailabilitiesPageHtmlLoaded += this.WebService_FirefighterAvailabilityList;
            this.webService.OperationListOfUserFirehousePageHtmlLoaded += this.WebService_OperationList;
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="NewOperation"/> and <see cref="NewOperationOfUserFirehouse"/> events of the <see cref="Statistics"/> class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="operations">A <see cref="Operation"/> array that contains the <see cref="Operation"/> added.</param>
        public delegate void OperationEventHandler(object sender, Operation[] operations);

        /// <summary>
        /// Represents the method that will handle the <see cref="FirehouseNameUpdated"/> event of the <see cref="Statistics"/> class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains no event data.</param>
        public delegate void FirehouseNameUpdatedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Represents the method that will handle the <see cref="FirefighterAvailabilitiesUpdated"/> event of the <see cref="Statistics"/> class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="firefighterAvailabilities">A <see cref="FirefighterAvailability"/> list.</param>
        public delegate void FirefighterAvailabilitiesUpdatedHandler(object sender, List<FirefighterAvailability> firefighterAvailabilities);

        /// <summary>
        /// Occurs when a new <see cref="Operation"/> is retrieved.
        /// </summary>
        public event OperationEventHandler NewOperation;

        /// <summary>
        /// Occurs when a new <see cref="Operation"/> of the user's firehouse is retrieved.
        /// </summary>
        public event OperationEventHandler NewOperationOfUserFirehouse;

        /// <summary>
        /// Occurs when a firehouse name is updated.
        /// </summary>
        public event FirehouseNameUpdatedEventHandler FirehouseNameUpdated;

        /// <summary>
        /// Occurs when a <see cref="FirefighterAvailability"/> list is updated.
        /// </summary>
        public event FirefighterAvailabilitiesUpdatedHandler FirefighterAvailabilitiesUpdated;

        /// <summary>
        /// Gets the firehouse's name of the user that used the softwarre.
        /// </summary>
        public string FirehouseName
        {
            get
            {
                return this.firehouseName;
            }

            private set
            {
                this.firehouseName = value;
                this.FirehouseNameUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the <see cref="Operation"/> list that contains all retrieved operations.
        /// </summary>
        public List<Operation> OperationList => this.operationDictionary.Select(c => c.Value).ToList();

        /// <summary>
        /// Gets the <see cref="Operation"/> list that contains all retrieved operations which are operations of the user's firehouse.
        /// </summary>
        public List<Operation> OperationListOfUserFirehouse => this.operationDictionary.Select(c => c.Value).Where(c => c.VehiclesTriggered.Any(t => t.Contains(this.FirehouseName))).ToList();

        /// <summary>
        /// Gets the <see cref="FirefighterAvailabilities"/> list that contains the availabilities of the firefighters of the user's firehouse.
        /// </summary>
        public List<FirefighterAvailability> FirefighterAvailabilities
        {
            get
            {
                return this.firefighterAvailabilities;
            }

            private set
            {
                this.firefighterAvailabilities = value;
                this.FirefighterAvailabilitiesUpdated?.Invoke(this, this.firefighterAvailabilities);
            }
        }

        /// <summary>
        /// Export an <see cref="Operation"/> list in a file.
        /// </summary>
        /// <param name="operations">A <see cref="Operation"/> list to be export.</param>
        /// <param name="fileName">A file's name where the operations list will be write.</param>
        public static void ExportOperationListToXml(List<Operation> operations, string fileName)
        {
            XmlSerializer xmlSerializer = new (operations.GetType());

            if (!Directory.Exists(Statistics.StatisticsFolderForSave))
            {
                _ = Directory.CreateDirectory(Statistics.StatisticsFolderForSave);
            }

            using (StreamWriter writer = new (Statistics.StatisticsFolderForSave + fileName))
            {
                xmlSerializer.Serialize(writer, operations);
                writer.Close();
            }
        }

        /// <summary>
        /// Sets the <see cref="Web.WebService"/> used by the statistics class for gets the last operations in department and ths firefighters' availabilities.
        /// </summary>
        public void Refresh()
        {
            this.webService.UrlQueue.Enqueue(Web.WebServiceURL.WebServiceOperationListURL);
            this.webService.UrlQueue.Enqueue(Web.WebServiceURL.WebServiceFirefighterAvailabilityURL);
            this.webService.NavigateToNextUrl();
        }

        /// <summary>
        /// Gets all operations in day.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> that contains the date of operations to be retrieved.</param>
        /// <returns>An <see cref="IEnumerable{Operation}"/> of the desired date.</returns>
        public IEnumerable<Operation> GetOperationsInDay(DateTime date)
        {
            return this.operationDictionary.Where(c => c.Value.StartedDateTimeLocal.Date == date.Date).Select(c => c.Value);
        }

        /// <summary>
        /// Gets the number of operations per hour.
        /// The array size will be 24. The first item will be the number of operations between midnight and 1:00 AM.
        /// </summary>
        /// <param name="date">A <see cref="DateTime"/> that contains the desired date.</param>
        /// <returns>An integer list that contains the number of operations per hour.</returns>
        public List<int> GetOperationPerHour(DateTime date)
        {
            var operationInDay = this.GetOperationsInDay(date);
            var operationPerHour = operationInDay.GroupBy(c => c.StartedDateTimeLocal.Hour, c => c.StartedDateTimeLocal, (hour, times) => (hour, count: times.Count())).ToArray();
            Array.Sort(operationPerHour, (x, y) => x.hour.CompareTo(y.hour));

            int[] operationPerHourArray = new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var (hour, count) in operationPerHour)
            {
                operationPerHourArray[hour] = count;
            }

            return operationPerHourArray.ToList();
        }

        /// <summary>
        /// Creates an <see cref="Operation"/> element with a <see cref="HtmlElement"/>.
        /// </summary>
        /// <param name="item">A <see cref="HtmlElement"/> that contains the operation data.</param>
        /// <returns>An <see cref="Operation"/> instance created.</returns>
        private static Operation HtmlElementToOperation(HtmlElement item)
        {
            string dateTimePatern = Regex.IsMatch(item.Children[0].InnerHtml, @"^[0-2]{0,1}[0-9]:[0-5]{0,1}[0-9]$") ? "HH:mm" : "dd/MM/yy HH:mm";
            DateTime time = DateTime.ParseExact(item.Children[0].InnerHtml, dateTimePatern, DateTimeProvider);
            int numOperation = int.Parse(item.Children[1].InnerText);
            string localisation = item.Children[2].GetElementsByTagName("b")[0].InnerHtml;
            string operationDescription = item.Children[2].Children[1].InnerText;

            Operation.EOperationType type = Operation.EOperationType.OTHER;
            if (item.Children[1].InnerHtml.Contains("/img/sap.gif"))
            {
                type = Operation.EOperationType.SAP;
            }
            else if (item.Children[1].InnerHtml.Contains("img/inc.gif"))
            {
                type = Operation.EOperationType.INC;
            }
            else if (item.Children[1].InnerHtml.Contains("img/od.gif"))
            {
                type = Operation.EOperationType.OD;
            }

            HashSet<string> vehiculeEnrolled = new ();
            foreach (HtmlElement vehicule in item.Children[3].GetElementsByTagName("div"))
            {
                _ = vehiculeEnrolled.Add(vehicule.InnerText);
            }

            return new Operation
            {
                StartedDateTimeLocal = time,
                NumOperation = numOperation,
                Type = type,
                Location = localisation,
                OperationDescription = operationDescription,
                VehiclesTriggered = vehiculeEnrolled,
            };
        }

        /// <summary>
        /// Updates an <see cref="Operation"/> already contained in a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="operationList">The <see cref="Dictionary{TKey, TValue}"/> that contains the operation to be updated.</param>
        /// <param name="operationUpdated">The <see cref="Operation"/> to be updated.</param>
        private static void UpdateOperation(Dictionary<int, Operation> operationList, Operation operationUpdated)
        {
            var operation = operationList.Where(c => operationUpdated.NumOperation == c.Key).Select(c => c.Value).ToList()[0];

            operation.Location = operationUpdated.Location;
            operation.OperationDescription = operationUpdated.OperationDescription;
            operation.StartedDateTimeLocal = operationUpdated.StartedDateTimeLocal;
            operation.Type = operationUpdated.Type;
            operation.VehiclesTriggered = operationUpdated.VehiclesTriggered;
        }

        /// <summary>
        /// Sets the urls wich initiliazes the statistics' values.
        /// </summary>
        private void Init()
        {
            this.webService.OperationListPageHtmlLoaded += this.WebService_OperationList_Init;

            this.webService.UrlQueue.Enqueue(Web.WebServiceURL.WebServiceOperationListURL);
            this.webService.UrlQueue.Enqueue(Web.WebServiceURL.WebServiceFirefighterAvailabilityURL);
            this.webService.UrlQueue.Enqueue(Web.WebServiceURL.WebServiceOperationListOfTheUserFirehouseURL);

            this.webService.NavigateToNextUrl();
        }

        /// <summary>
        /// Called when the <see cref="Web.WebServiceURL.WebServiceOperationListURL"/> or the <see cref="Web.WebServiceURL.WebServiceOperationListOfTheUserFirehouseURL"/> urls are loaded in the <see cref="Web.WebService"/> and the statistics instance is in the init state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="htmlDocument">A <see cref="HtmlDocument"/> that contains the values of the operations.</param>
        private void WebService_OperationList_Init(object sender, HtmlDocument htmlDocument)
        {
            try
            {
                var paginator = htmlDocument.GetElementsByTagName("li").Cast<HtmlElement>();

                int currentPage = paginator.Where(c => c.OuterHtml.Contains("class=active")).Any() ? int.Parse(paginator.Where(c => c.OuterHtml.Contains("class=active")).First().InnerText) : 1;

                bool isLastPage = !paginator.Where(c => c.OuterHtml.Contains("class=last")).Any();

                if (isLastPage)
                {
                    this.webService.OperationListPageHtmlLoaded -= this.WebService_OperationList_Init;
                }
                else
                {
                    var url = Web.WebServiceURL.WebServiceOperationListURL;
                    url.QueryParameters["page"] = (currentPage + 1).ToString();
                    this.webService.UrlQueue.Enqueue(url);

                    this.webService.NavigateToNextUrl();
                }
            }
            catch (Exception e)
            {
                Syst.Log.WriteLog(Syst.Log.EType.Error, "Error. " + e.Message);
            }
        }

        /// <summary>
        /// Called when the <see cref="Web.WebServiceURL.WebServiceMainPageURL"/> url is loaded in the <see cref="Web.WebService"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="htmlDocument">A <see cref="HtmlDocument"/> that contains the html of the main page.</param>
        private void WebService_MainPage(object sender, HtmlDocument htmlDocument)
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

        /// <summary>
        /// Called when the <see cref="Web.WebServiceURL.WebServiceOperationListURL"/> or the <see cref="Web.WebServiceURL.WebServiceOperationListOfTheUserFirehouseURL"/> urls are loaded.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="htmlDocument">A <see cref="HtmlDocument"/> that contains the values of the operations.</param>
        private void WebService_OperationList(object sender, HtmlDocument htmlDocument)
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
                    UpdateOperation(this.operationDictionary, operation);
                    updatedOperationList.Add(operation);
                }
                else
                {
                    this.operationDictionary.Add(operation.NumOperation, operation);
                    newOperationList.Add(operation);
                }
            }

            if (newOperationList.Any())
            {
                var operationListOfUserFirehouse = newOperationList.Where(c => c.VehiclesTriggered.Any(t => t.Contains(this.FirehouseName)));

                this.NewOperation?.Invoke(this, newOperationList.ToArray());

                if (operationListOfUserFirehouse.Any())
                {
                    this.NewOperationOfUserFirehouse?.Invoke(this, operationListOfUserFirehouse.ToArray());
                }
            }
        }

        /// <summary>
        /// Called when the <see cref="Web.WebServiceURL.WebServiceFirefighterAvailabilityURL"/> url is loaded in the <see cref="Web.WebService"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="htmlDocument">A <see cref="HtmlDocument"/> that contains the values of the firefighters' availabilities.</param>
        private void WebService_FirefighterAvailabilityList(object sender, HtmlDocument htmlDocument)
        {
            var data = htmlDocument.GetElementById("liste-dipo");
            data = data.GetElementsByTagName("tbody")[0];
            var firefighterList = data.GetElementsByTagName("tr");

            this.FirefighterAvailabilities?.Clear();

            var newList = new List<FirefighterAvailability>();

            foreach (HtmlElement firefighter in firefighterList)
            {
                var content = firefighter.GetElementsByTagName("td");

                var availability = content[0].InnerText switch
                {
                    "\r\nDisponible sur place" => FirefighterAvailability.EAvailability.AvailableOnSite,
                    "\r\nDisponible 5 min" => FirefighterAvailability.EAvailability.Available5Min,
                    "\r\nDisponible 10 min" => FirefighterAvailability.EAvailability.Available10Min,
                    "\r\nEn intervention" => FirefighterAvailability.EAvailability.InIntervention,
                    _ => FirefighterAvailability.EAvailability.NotAvailable,
                };

                string matricule = content[1].InnerText;
                string name = content[2].InnerText;
                string rank = content[3].InnerText;

                newList.Add(new FirefighterAvailability
                {
                    Availability = availability,
                    RegistrationNumber = matricule,
                    Name = name,
                    Rank = rank,
                });
            }

            this.FirefighterAvailabilities = newList;
        }
    }
}
