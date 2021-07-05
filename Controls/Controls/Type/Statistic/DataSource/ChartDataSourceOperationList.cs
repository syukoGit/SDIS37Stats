// -----------------------------------------------------------------------
// <copyright file="ChartDataSourceOperationList.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Controls.Type.Statistic.DataSource
{
    using System;
    using System.Collections.Generic;
    using DevExpress.WinUI.Charts;

    /// <summary>
    /// Class used for provides the number of <see cref="SDIS37Stats.Core.Statistics.Operation"/> per hour to a chart.
    /// </summary>
    internal class ChartDataSourceOperationList : ChartDataAdapter
    {
        /// <summary>
        /// Data used by a chart.
        /// </summary>
        private List<int> data = new ();

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<int> Data
        {
            get
            {
                return this.data;
            }

            set
            {
                this.data = value;
                this.OnDataChanged(ChartDataUpdateType.Reset, -1);
            }
        }

        /// <summary>
        /// Gets the rows count.
        /// </summary>
        protected override int RowsCount => this.data.Count;

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="index">Position of the element in data.</param>
        /// <param name="dataMember">specifies which attribute of a data point.</param>
        /// <returns>Returns nothing because not implemented.</returns>
        protected override DateTime GetDateTimeValue(int index, ChartDataMemberType dataMember)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the element int data.
        /// </summary>
        /// <param name="index">Position of the element in data.</param>
        /// <returns>Returns the element.</returns>
        protected override object GetKey(int index)
        {
            return this.data[index];
        }

        /// <summary>
        /// Gets the numeral value.
        /// </summary>
        /// <param name="index">Position of the element in data.</param>
        /// <param name="dataMember">Specifies which attribute of a data point.</param>
        /// <returns>Returns the numerical value.</returns>
        protected override double GetNumericalValue(int index, ChartDataMemberType dataMember)
        {
            return this.data[index];
        }

        /// <summary>
        /// Gets the qualitative value.
        /// </summary>
        /// <param name="index">Position of the element in data.</param>
        /// <param name="dataMember">Specifies which attribute of a data point.</param>
        /// <returns>Returns the qualitative value.</returns>
        protected override string GetQualitativeValue(int index, ChartDataMemberType dataMember)
        {
            return this.data[index] + "h";
        }

        /// <summary>
        /// Gets the scale type.
        /// </summary>
        /// <param name="dataMember">Specifies which attribute of a data point.</param>
        /// <returns>Returns the scale type.</returns>
        protected override ActualScaleType GetScaleType(ChartDataMemberType dataMember)
        {
            return dataMember == ChartDataMemberType.Argument ? ActualScaleType.Qualitative : ActualScaleType.Numerical;
        }
    }
}
