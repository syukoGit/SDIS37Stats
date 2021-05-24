//-----------------------------------------------------------------------
// <copyright file="NbOperationPerHour.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.Statistics
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Class for make the <see cref="Graph.BarGraph"/> which display the number of <see cref="Core.Statistics.Operation"/> per hour.
    /// </summary>
    public partial class NbOperationPerHour : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NbOperationPerHour"/> class.
        /// </summary>
        public NbOperationPerHour()
        {
            this.InitializeComponent();

            Core.Syst.Setting.CurrentSetting.ThemeUpdated += this.CurrentSetting_ThemeUpdated;
        }

        /// <summary>
        /// Gets or sets the values to be displayed.
        /// </summary>
        public List<int> Value
        {
            get
            {
                return this.barGraph.Value;
            }

            set
            {
                if (value != null && value.Count == 24)
                {
                    this.barGraph.Value = value;
                }
            }
        }

        /// <summary>
        /// Apply a <see cref="Extra.Theme.ITheme"/> on this control.
        /// </summary>
        /// <param name="theme">A theme to be applied.</param>
        public void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor;
            this.ForeColor = theme.Form_FontColor;

            this.tableLayoutPanel1.BackColor = theme.Graph_BackgroundColor;

            this.fix_label.ForeColor = theme.Form_FontColor;

            this.barGraph.BackGroundGraphColor = theme.Graph_BackgroundGraphColor;
            this.barGraph.AxisColor = theme.Graph_AxisColor;
            this.barGraph.MainBarColor = theme.Graph_MainColor;
            this.barGraph.ValueColor = theme.Form_FontColor;
        }

        /// <summary>
        /// Called when the theme is updated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains no event data.</param>
        private void CurrentSetting_ThemeUpdated(object sender, System.EventArgs e)
        {
            this.ApplyTheme(((Core.Syst.Setting)sender).Theme);
        }
    }
}
