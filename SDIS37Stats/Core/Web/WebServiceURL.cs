namespace SDIS37Stats.Core.Web
{
    internal class WebServiceURL
    {
        /// <summary>
        /// Used for get the login url of the webservice.
        /// </summary>
        public static URL WebServicesLoginURL = new URL("https://webservices.sdis37.fr/users/login");

        /// <summary>
        /// Used for get the main page of the webservice.
        /// </summary>
        public static URL WebServiceMainPageURL = new URL("https://webservices.sdis37.fr/interventions");

        /// <summary>
        /// Used for get the number of operation in day.
        /// </summary>
        public static URL WebServiceNbOperationInDayURL = new URL("https://webservices.sdis37.fr/interventions/nbInterventions")
        {
            PostDatas = new PostData[]
            {
                new PostData("date") { DefaultValue = "01/01/2021" },
                new PostData("rbcsp") { DefaultValue = "SDIS" }
            }
        };

        /// <summary>
        /// Used for get the number of operations per hour.
        /// </summary>
        public static URL WebServiceStatsForOperationPerHourURL = new URL("https://webservices.sdis37.fr/interventions/getNb");

        /// <summary>
        /// Used for get the lis of recent operations in SDIS37.
        /// </summary>
        public static URL WebServiceRecentOperationListURL = new URL("https://webservices.sdis37.fr/interventions/liste")
        {
            QueryParameters = new QueryParameter[]
            { 
                new QueryParameter("direction") { DefaultValue = "desc" },
                new QueryParameter("sort") { DefaultValue = "Depart" },
                new QueryParameter("page")
            }
        };

        /// <summary>
        /// Used for get the list of the recent operations in the user's firehouse.
        /// </summary>
        public static URL WebServiceRecentOperationListOfTheUserFirehouseURL = new URL("https://webservices.sdis37.fr/interventions/listestats/undefined")
        {
            QueryParameters = new QueryParameter[]
            {
                new QueryParameter("direction") { DefaultValue = "desc" },
                new QueryParameter("sort") { DefaultValue = "Depart" },
                new QueryParameter("page")
            }
        };

        /// <summary>
        /// Used for get the availabilities of the firefighters of the user's firehouse.
        /// </summary>
        public static URL WebServiceFirefighterAvailabilityURL = new URL("https://webservices.sdis37.fr/personnels");
    }
}