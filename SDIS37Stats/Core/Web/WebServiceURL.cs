// -----------------------------------------------------------------------
// <copyright file="WebServiceURL.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Web
{
    /// <summary>
    /// Internal class containing the <see cref="URL"/> used by the <see cref="WebService"/> class.
    /// </summary>
    internal class WebServiceURL
    {
        /// <summary>
        /// Used for get the login url of the webservice.
        /// </summary>
        public static readonly URL WebServicesLoginURL = new ("https://webservices.sdis37.fr/users/login");

        /// <summary>
        /// Used for get the main page of the webservice.
        /// </summary>
        public static readonly URL WebServiceMainPageURL = new ("https://webservices.sdis37.fr/interventions");

        /// <summary>
        /// Used for get the number of operation in day.
        /// </summary>
        public static readonly URL WebServiceNbOperationInDayURL = new ("https://webservices.sdis37.fr/interventions/nbInterventions")
        {
            PostDatas = new PostData[]
            {
                new PostData("date") { DefaultValue = "01/01/2021" },
                new PostData("rbcsp") { DefaultValue = "SDIS" },
            },
        };

        /// <summary>
        /// Used for get the number of operations per hour.
        /// </summary>
        public static readonly URL WebServiceStatsForOperationPerHourURL = new ("https://webservices.sdis37.fr/interventions/getNb");

        /// <summary>
        /// Used for get the lis of recent operations in SDIS37.
        /// </summary>
        public static readonly URL WebServiceOperationListURL = new ("https://webservices.sdis37.fr/interventions/liste")
        {
            QueryParameters = new QueryParameter[]
            {
                new QueryParameter("direction") { DefaultValue = "desc" },
                new QueryParameter("sort") { DefaultValue = "Depart" },
                new QueryParameter("page"),
            },
        };

        /// <summary>
        /// Used for get the list of the recent operations in the user's firehouse.
        /// </summary>
        public static readonly URL WebServiceOperationListOfTheUserFirehouseURL = new ("https://webservices.sdis37.fr/interventions/listestats/undefined")
        {
            QueryParameters = new QueryParameter[]
            {
                new QueryParameter("direction") { DefaultValue = "desc" },
                new QueryParameter("sort") { DefaultValue = "Depart" },
                new QueryParameter("page"),
            },
        };

        /// <summary>
        /// Used for get the availabilities of the firefighters of the user's firehouse.
        /// </summary>
        public static readonly URL WebServiceFirefighterAvailabilityURL = new ("https://webservices.sdis37.fr/personnels");
    }
}