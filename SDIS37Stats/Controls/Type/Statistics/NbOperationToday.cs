//-----------------------------------------------------------------------
// <copyright file="NbOperationToday.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.Statistics
{
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Class for display the number of <see cref="Core.Statistics.Operation"/> today.
    /// </summary>
    public partial class NbOperationToday : UserControl
    {
        /// <summary>
        /// Represents the statistics manager.
        /// </summary>
        private Core.Statistics.Statistics statistics = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NbOperationToday"/> class.
        /// </summary>
        public NbOperationToday()
        {
            this.InitializeComponent();

            Core.Syst.Setting.CurrentSetting.ThemeUpdated += this.CurrentSetting_ThemeUpdated;

            this.ApplyTheme(Core.Syst.Setting.CurrentSetting.Theme);
        }

        /// <summary>
        /// Gets or sets the statistics manager.
        /// </summary>
        public Core.Statistics.Statistics Statistics
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
        /// Apply a <see cref="Extra.Theme.ITheme"/> on this control.
        /// </summary>
        /// <param name="theme">A theme to be applied.</param>
        public void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor;
            this.ForeColor = theme.Form_FontColor;

            this.fix_label.ForeColor = theme.Form_FontColor;

            this.sevenSegmentArray1.ColorBackground = theme.Form_BackgroundColor;
            this.sevenSegmentArray1.ColorDark = theme.SevenSegment_DarkColor;
            this.sevenSegmentArray1.ColorLight = theme.SevenSegment_LightColor;
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

        /// <summary>
        /// Called when an operation is added.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="operations">An <see cref="Core.Statistics.Operation"/> array that contains added operation.</param>
        private void Statistics_NewOperation(object sender, Core.Statistics.Operation[] operations)
        {
            this.sevenSegmentArray1.Value = (sender as Core.Statistics.Statistics).GetOperationsInDay(System.DateTime.Now).Count();
        }
    }
}
