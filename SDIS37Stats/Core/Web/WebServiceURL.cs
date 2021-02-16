namespace SDIS37Stats.Core.Web
{
    internal class WebServiceURL
    {
        /// <summary>
        /// Const string used for get the login url of the webservice.
        /// </summary>
        public const string WebServicesLoginURL = "https://webservices.sdis37.fr/users/login";

        /// <summary>
        /// Const string used for get the main page of the webservice.
        /// </summary>
        public const string WebServiceMainPageURL = "https://webservices.sdis37.fr/interventions";

        /// <summary>
        /// Const string used for get the number of operation in day.
        /// </summary>
        public const string WebServiceNbOperationInDayURL = "https://webservices.sdis37.fr/interventions/nbInterventions";

        /// <summary>
        /// Const string used for get the number of operations per hour.
        /// </summary>
        public const string WebServiceStatsForOperationPerHourURL = "https://webservices.sdis37.fr/interventions/getNb";

        /// <summary>
        /// Const string used for get the lis of recent operations in SDIS37.
        /// </summary>
        public const string WebServiceRecentOperationListURL = "https://webservices.sdis37.fr/interventions/liste?direction=desc&sort=Depart";

        /// <summary>
        /// Const string used for get the availabilities of the firefighters of the user's firehouse.
        /// </summary>
        public const string WebServiceFirefighterAvailabilityURL = "https://webservices.sdis37.fr/personnels";
    }
}