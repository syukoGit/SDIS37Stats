// -----------------------------------------------------------------------
// <copyright file="WebServiceURL.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Web
{
    using System.Collections.Generic;

    /// <summary>
    /// Internal class containing the <see cref="URL"/> used by the <see cref="WebService"/> class.
    /// </summary>
    internal class WebServiceURL
    {
        /// <summary>
        /// Gets the <see cref="URL"/> for get the login url of the webservice.
        /// </summary>
        public static URL WebServicesLoginURL => new ("https://webservices.sdis37.fr/users/login");

        /// <summary>
        /// Gets the <see cref="URL"/> for get the main page of the webservice.
        /// </summary>
        public static URL WebServiceMainPageURL => new ("https://webservices.sdis37.fr/interventions");

        /// <summary>
        /// Gets the <see cref="URL"/> get the number of operation in day.
        /// <para>The available post data:
        ///     <list type="bullet">
        ///         <item>
        ///             <term>date</term>
        ///             <description>Date of the day on wich one wishes to retrieve the information. Default value: 01/01/2021.</description>
        ///         </item>
        ///         <item>
        ///             <term>rbcsp</term>
        ///             <description>Acronym of principal firehouse or department Available values: SDIS/AMB/CHI/LOC/NAG/TCN/SAG | Default value: SDIS.</description>
        ///         </item>
        ///     </list>
        /// </para>
        /// </summary>
        public static URL WebServiceNbOperationInDayURL => new ("https://webservices.sdis37.fr/interventions/nbInterventions")
        {
            PostData = new Dictionary<string, string>
            {
                { "date", "01/01/2021" },
                { "rbcsp", "SDIS" },
            },
        };

        /// <summary>
        /// Gets <see cref="URL"/> for get the number of operations per hour.
        /// </summary>
        public static URL WebServiceStatsForOperationPerHourURL => new ("https://webservices.sdis37.fr/interventions/getNb");

        /// <summary>
        /// Gets the <see cref="URL"/> for get the list of recent operations in SDIS37.
        /// <para>
        ///     <list type="bullet">
        ///         <item>
        ///             <term>direction</term>
        ///             <description>Defines the order of the data. Available value: desc/asc</description>
        ///         </item>
        ///         <item>
        ///             <term>sort</term>
        ///             <description>Defines the sort applied to the data.</description>
        ///         </item>
        ///         <item>
        ///             <term>page</term>
        ///             <description>Defines the page. Default value: last page</description>
        ///         </item>
        ///     </list>
        /// </para>
        /// </summary>
        public static URL WebServiceOperationListURL => new ("https://webservices.sdis37.fr/interventions/liste")
        {
            QueryParameters = new Dictionary<string, string>
            {
                { "direction", "desc" },
                { "sort", "Depart" },
            },
        };

        /// <summary>
        /// Gets the <see cref="URL"/> for get the list of the recent operations in the user's firehouse.
        /// <para>
        ///     <list type="bullet">
        ///         <item>
        ///             <term>direction</term>
        ///             <description>Defines the order of the data. Available value: desc/asc</description>
        ///         </item>
        ///         <item>
        ///             <term>sort</term>
        ///             <description>Defines the sort applied to the data.</description>
        ///         </item>
        ///         <item>
        ///             <term>page</term>
        ///             <description>Defines the page. Default value: last page</description>
        ///         </item>
        ///     </list>
        /// </para>
        /// </summary>
        public static URL WebServiceOperationListOfTheUserFirehouseURL => new ("https://webservices.sdis37.fr/interventions/listestats/undefined")
        {
            QueryParameters = new Dictionary<string, string>
            {
                { "direction", "desc" },
                { "sort", "Depart" },
            },
        };

        /// <summary>
        /// Gets the <see cref="URL"/> for get the availabilities of the firefighters of the user's firehouse.
        /// </summary>
        public static URL WebServiceFirefighterAvailabilityURL => new ("https://webservices.sdis37.fr/personnels");
    }
}