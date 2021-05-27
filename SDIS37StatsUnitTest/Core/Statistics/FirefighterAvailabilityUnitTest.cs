// -----------------------------------------------------------------------
// <copyright file="FirefighterAvailabilityUnitTest.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37StatsUnitTest.Core.Statistics
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SDIS37Stats.Core.Statistics;

    /// <summary>
    /// Class for the unit tests of the <see cref="FirefighterAvailability"/> class.
    /// </summary>
    [TestClass]
    public class FirefighterAvailabilityUnitTest
    {
        /// <summary>
        /// Unit test for tests the CompareTo function of the <see cref="FirefighterAvailability"/> class.
        /// </summary>
        /// <param name="fa1">A <see cref="FirefighterAvailability"/> to be tested.</param>
        /// <param name="fa2">A <see cref="FirefighterAvailability"/> to be tested on the first firefighter's availability.</param>
        /// <param name="expected">The result to be achieved.</param>
        [DataTestMethod]
        [DynamicData(nameof(FirefighterAvailabilityHelper.DataForCompareTo), typeof(FirefighterAvailabilityHelper), DynamicDataSourceType.Property)]
        [TestCategory("SDIS37StatsUnitTest.Core.Statistics")]
        public void FirefighterAvailability_CompareTo(FirefighterAvailability fa1, FirefighterAvailability fa2, int expected)
        {
            int result = fa1.CompareTo(fa2);

            Assert.AreEqual(expected, result, $"Expected :{result} \\ Actual :{result}");
        }
    }
}