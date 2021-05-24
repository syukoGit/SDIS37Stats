//-----------------------------------------------------------------------
// <copyright file="Operation.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Core.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Class for make a operation in the department.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Enumeration of different operation types.
        /// </summary>
        public enum EOperationType
        {
            /// <summary>
            /// The operation is a personal assistance.
            /// </summary>
            [XmlEnum(Name = "Personal assistance")]
            SAP,

            /// <summary>
            /// The operation is a diverse operation.
            /// </summary>
            [XmlEnum(Name = "Diverse operation")]
            OD,

            /// <summary>
            /// The operation is a fire.
            /// </summary>
            [XmlEnum(Name = "Fire")]
            INC,

            /// <summary>
            /// The operation is not a personal assistance, diverse operation or fire.
            /// </summary>
            [XmlEnum(Name = "Other operation")]
            OTHER,
        }

        /// <summary>
        /// Gets or sets the started date and time of the operation.
        /// </summary>
        public DateTime StartedDateTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the number of the operation.
        /// </summary>
        public int NumOperation { get; set; }

        /// <summary>
        /// Gets or sets the type of the operation.
        /// </summary>
        public EOperationType Type { get; set; }

        /// <summary>
        /// Gets or sets the location of the operation.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the description of the operation.
        /// </summary>
        public string OperationDescription { get; set; }

        /// <summary>
        /// Gets or sets the list of the firefighter vehicles triggered for the operation.
        /// </summary>
        public HashSet<string> VehiclesTriggered { get; set; }
    }
}
