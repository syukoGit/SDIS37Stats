// -----------------------------------------------------------------------
// <copyright file="NbOperationPerHour.xaml.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Controls.Type.Statistic
{
    using Microsoft.UI.Xaml.Controls;
    using SDIS37Stats.Core.Statistics;

    /// <summary>
    /// Class for make a bar chart which display the number of operation per hour.
    /// </summary>
    public sealed partial class NbOperationPerHour : UserControl
    {
        /// <summary>
        /// Represents the chart's source.
        /// </summary>
        private readonly DataSource.ChartDataSourceOperationList source;

        /// <summary>
        /// Represents the statistics source.
        /// </summary>
        private Statistics statistics;

        /// <summary>
        /// Initializes a new instance of the <see cref="NbOperationPerHour"/> class.
        /// </summary>
        public NbOperationPerHour()
        {
            this.InitializeComponent();

            this.source = new ();

            this.statistics.NewOperation += this.Statistics_NewOperation;
        }

        public System.Collections.Generic.List<int> tdte
        {
            get
            {
                return this.source.Data;
            }

            set
            {
                this.source.Data = value;
            }
        }

        /// <summary>
        /// Gets or sets the statistics manager.
        /// </summary>
        public Statistics Statistics
        {
            get
            {
                return this.statistics;
            }

            set
            {
                if (this.statistics != null)
                {
                    this.statistics.NewOperation -= this.Statistics_NewOperation;
                }

                this.statistics = value;

                if (this.statistics != null)
                {
                    this.statistics.NewOperation += this.Statistics_NewOperation;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Y axis title.
        /// </summary>
        public string AxisYTitle { get; set; } = "Nombre d'intervention";

        /// <summary>
        /// Gets or sets the Y axis title.
        /// </summary>
        public string AxisXTitle { get; set; } = "Heure";

        /// <summary>
        /// Called when a new operation is retrieved.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="operations">a <see cref="Operation"/> array that contains the new operations.</param>
        private void Statistics_NewOperation(object sender, Operation[] operations)
        {
            this.source.Data = (sender as Statistics).GetOperationPerHour(System.DateTime.Now);
        }
    }
}
