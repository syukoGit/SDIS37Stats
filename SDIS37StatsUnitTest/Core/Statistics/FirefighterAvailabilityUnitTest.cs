namespace SDIS37StatsUnitTest.Core.Statistics
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDIS37Stats.Core.Statistics;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestClass]
    public class FirefighterAvailabilityUnitTest
    {
        [DataTestMethod]
        [DynamicData(nameof(Helper.DataForCompareTo), typeof(Helper), DynamicDataSourceType.Property)]
        [TestCategory("SDIS37StatsUnitTest.Core.Statistics")]
        public void FirefighterAvailability_CompareTo(FirefighterAvailability fa1, FirefighterAvailability fa2, int expected)
        {
            int result = fa1.CompareTo(fa2);

            Assert.AreEqual(expected, result, $"Expected :{ result } \\ Actual :{ result }");
        }
    }

    internal class Helper
    {
        public static IEnumerable<object[]> DataForCompareTo
        {
            get
            {
                yield return new object[]
                {
                    new FirefighterAvailability{ Availability = FirefighterAvailability.AVAILABILITY.AvailableOnSite, Matricule = "603210V", Name = "AXEL AA", Rank = "SA1" },
                    new FirefighterAvailability{ Availability = FirefighterAvailability.AVAILABILITY.InIntervention, Matricule = "602422V", Name = "ROBERT TT", Rank = "SA2" },
                    1
                };
                yield return new object[]
                {
                    new FirefighterAvailability{ Availability = FirefighterAvailability.AVAILABILITY.AvailableOnSite, Matricule = "603210V", Name = "AXEL AA", Rank = "SA1" },
                    new FirefighterAvailability{ Availability = FirefighterAvailability.AVAILABILITY.AvailableOnSite, Matricule = "602422V", Name = "ROBERT TT", Rank = "SA2" },
                    -1
                };
                yield return new object[]
                {
                    new FirefighterAvailability{ Availability = FirefighterAvailability.AVAILABILITY.AvailableOnSite, Matricule = "603210V", Name = "AXEL AA", Rank = "SA1" },
                    new FirefighterAvailability{ Availability = FirefighterAvailability.AVAILABILITY.AvailableOnSite, Matricule = "602422V", Name = "AXEL AA", Rank = "SA2" },
                    0
                };
                yield return new object[]
                {
                    new FirefighterAvailability{ Availability = FirefighterAvailability.AVAILABILITY.AvailableOnSite, Matricule = "603210V", Name = "AXEL AA", Rank = "SA1" },
                    null,
                    1
                };
            }
        }
    }
}