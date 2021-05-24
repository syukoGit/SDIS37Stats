//-----------------------------------------------------------------------
// <copyright file="FirefighterAvailability.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Core.Statistics
{
    using System;

    /// <summary>
    /// Class for make a firefighter availability. It implements a <see cref="IComparable"/> interface for compare two <see cref="FirefighterAvailability"/>.
    /// </summary>
    public class FirefighterAvailability : IComparable<FirefighterAvailability>
    {
        /// <summary>
        /// Enumeration of different firefighter availabilities available.
        /// </summary>
        public enum EAvailability
        {
            /// <summary>
            /// The firefighter is available on his firehouse.
            /// </summary>
            AvailableOnSite = 1,

            /// <summary>
            /// The firefighter is available but he is five minutes from his firehouse.
            /// </summary>
            Available5Min = 2,

            /// <summary>
            /// The firefighter is available but he is ten minutes from his firehouse.
            /// </summary>
            Available10Min = 3,

            /// <summary>
            /// The firefighter is not available.
            /// </summary>
            NotAvailable = 4,

            /// <summary>
            /// The firefighter is on a operation.
            /// </summary>
            InIntervention = 0,
        }

        /// <summary>
        /// Gets or sets the firefighter's availability.
        /// </summary>
        public EAvailability Availability { get; set; }

        /// <summary>
        /// Gets or sets the firefighter's registration number.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the firefighter's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the firefighter's rank.
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Return a string represents the current object.
        /// </summary>
        /// <returns>A string that represents the object.</returns>
        public override string ToString()
        {
            return this.Rank + " / " + this.Name + " / " + this.Availability.ToString();
        }

        /// <summary>
        /// Compare two <see cref="FirefighterAvailability"/> instances.
        /// </summary>
        /// <param name="obj">A <see cref="FirefighterAvailability"/> instance to be compared to the current instance.</param>
        /// <returns>A integer that represents if the current instance is after, equals or before the compared <see cref="FirefighterAvailability"/> instance.</returns>
        public int CompareTo(FirefighterAvailability obj)
        {
            if (obj == null)
            {
                return 1;
            }

            int compareToValue = this.Availability.CompareTo(obj.Availability);

            return compareToValue == 0 ? this.Name.CompareTo(obj.Name) : compareToValue;
        }
    }
}
