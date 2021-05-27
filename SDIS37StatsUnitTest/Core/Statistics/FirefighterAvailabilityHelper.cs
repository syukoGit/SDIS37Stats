// -----------------------------------------------------------------------
// <copyright file="FirefighterAvailabilityHelper.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37StatsUnitTest.Core.Statistics
{
    using System.Collections.Generic;
    using SDIS37Stats.Core.Statistics;

    /// <summary>
    /// Helper of the <see cref="FirefighterAvailabilityUnitTest"/> class.
    /// </summary>
    internal class FirefighterAvailabilityHelper
    {
        /// <summary>
        /// Gets list of object array used for the CompareTo function in the <see cref="FirefighterAvailabilityUnitTest.FirefighterAvailability_CompareTo(FirefighterAvailability, FirefighterAvailability, int)"/> unit test.
        /// </summary>
        public static IEnumerable<object[]> DataForCompareTo
        {
            get
            {
                yield return new object[]
                {
                    new FirefighterAvailability { Availability = FirefighterAvailability.EAvailability.AvailableOnSite, RegistrationNumber = "603210V", Name = "AXEL AA", Rank = "SA1" },
                    new FirefighterAvailability { Availability = FirefighterAvailability.EAvailability.InIntervention, RegistrationNumber = "602422V", Name = "ROBERT TT", Rank = "SA2" },
                    1,
                };
                yield return new object[]
                {
                    new FirefighterAvailability { Availability = FirefighterAvailability.EAvailability.AvailableOnSite, RegistrationNumber = "603210V", Name = "AXEL AA", Rank = "SA1" },
                    new FirefighterAvailability { Availability = FirefighterAvailability.EAvailability.AvailableOnSite, RegistrationNumber = "602422V", Name = "ROBERT TT", Rank = "SA2" },
                    -1,
                };
                yield return new object[]
                {
                    new FirefighterAvailability { Availability = FirefighterAvailability.EAvailability.AvailableOnSite, RegistrationNumber = "603210V", Name = "AXEL AA", Rank = "SA1" },
                    new FirefighterAvailability { Availability = FirefighterAvailability.EAvailability.AvailableOnSite, RegistrationNumber = "602422V", Name = "AXEL AA", Rank = "SA2" },
                    0,
                };
                yield return new object[]
                {
                    new FirefighterAvailability { Availability = FirefighterAvailability.EAvailability.AvailableOnSite, RegistrationNumber = "603210V", Name = "AXEL AA", Rank = "SA1" },
                    null,
                    1,
                };
            }
        }
    }
}