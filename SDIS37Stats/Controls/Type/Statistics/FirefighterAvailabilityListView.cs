//-----------------------------------------------------------------------
// <copyright file="FirefighterAvailabilityListView.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Class for make a view of a <see cref="FirefighterAvailabilityView"/> list.
    /// </summary>
    public partial class FirefighterAvailabilityListView : UserControl
    {
        /// <summary>
        /// List of <see cref="FirefighterAvailability"/> to be displayed.
        /// </summary>
        private readonly List<Core.Statistics.FirefighterAvailability> data = new ();

        /// <summary>
        /// Currently displayed control index.
        /// </summary>
        private int currentControl = 0;

        /// <summary>
        /// Maximum number of <see cref="FirefighterAvailabilityView"/> to be displayed.
        /// </summary>
        private int numAvailibilitiesDisplayed = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="FirefighterAvailabilityListView"/> class.
        /// </summary>
        public FirefighterAvailabilityListView()
        {
            this.InitializeComponent();

            Core.Syst.Setting.CurrentSetting.ThemeUpdated += this.CurrentSetting_ThemeUpdated;

            this.timerAutoScroll.Start();
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get => this.title.Text;
            set => this.title.Text = value;
        }

        /// <summary>
        /// Gets or sets the maximum number of <see cref="FirefighterAvailabilityView"/> to be displayed.
        /// </summary>
        public int NumberOfAvailibilitiesDisplayed
        {
            get
            {
                return this.numAvailibilitiesDisplayed;
            }

            set
            {
                this.numAvailibilitiesDisplayed = value;

                this.SetFirefighterAvailabilityViews();
            }
        }

        /// <summary>
        /// Apply the theme on this control and the controls it contains.
        /// </summary>
        /// <param name="theme">A theme to be applied.</param>
        public void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor;
            this.ForeColor = theme.Form_FontColor;

            this.tableLayoutMain.BackColor = theme.FirefighterAvailabilityListView_BackgroundColor;

            this.title.ForeColor = theme.Form_FontColor;

            this.panel.BackColor = theme.FirefighterAvailabilityListView_BackgroundList;
            this.tableFirefighterAvailabilityViews.BackColor = theme.FirefighterAvailabilityListView_BackgroundList;

            foreach (Control item in this.tableFirefighterAvailabilityViews.Controls)
            {
                item.BackColor = theme.FirefighterAvailabilityListView_BackgroundColorItem;
                item.ForeColor = theme.Form_FontColor;
            }
        }

        /// <summary>
        /// Set the <see cref="FirefighterAvailabilityView"/> list to be displayed.
        /// </summary>
        /// <param name="firefighterAvailabilities">The <see cref="FirefighterAvailabilityView"/> list to be displayed.</param>
        public void SetFirefighterAvailabilities(IEnumerable<Core.Statistics.FirefighterAvailability> firefighterAvailabilities)
        {
            this.data.Clear();
            this.data.AddRange(firefighterAvailabilities);

            this.SetFirefighterAvailabilityViews();
        }

        /// <summary>
        /// Display the <see cref="FirefighterAvailabilityView"/> list.
        /// </summary>
        private void SetFirefighterAvailabilityViews()
        {
            this.timerAutoScroll.Stop();

            this.tableFirefighterAvailabilityViews.SuspendLayout();

            if (this.tableFirefighterAvailabilityViews.Controls.Count > this.NumberOfAvailibilitiesDisplayed)
            {
                for (int i = this.tableFirefighterAvailabilityViews.Controls.Count - 1; i >= this.NumberOfAvailibilitiesDisplayed || i >= this.data.Count; i--)
                {
                    var firefighterAvailabilityView = this.tableFirefighterAvailabilityViews.Controls[i];
                    this.tableFirefighterAvailabilityViews.Controls.Remove(firefighterAvailabilityView);
                    firefighterAvailabilityView?.Dispose();
                }
            }
            else
            {
                for (int i = this.tableFirefighterAvailabilityViews.Controls.Count; i < this.NumberOfAvailibilitiesDisplayed && i < this.data.Count; i++)
                {
                    this.tableFirefighterAvailabilityViews.Controls.Add(new FirefighterAvailabilityView()
                    {
                        Dock = DockStyle.Fill,
                    });
                }
            }

            if (this.data != null && this.data.Any())
            {
                this.data.Sort((a, b) => a.CompareTo(b));

                System.Collections.IList controlList = this.tableFirefighterAvailabilityViews.Controls;
                for (int i = 0; i < controlList.Count; i++)
                {
                    var firefighterAvailabilityView = controlList[i] as FirefighterAvailabilityView;

                    if (firefighterAvailabilityView.FirefighterAvailability != this.data[i])
                    {
                        firefighterAvailabilityView.FirefighterAvailability = this.data[i];
                    }
                }
            }

            this.ApplyTheme(Core.Syst.Setting.CurrentSetting.Theme);

            this.tableFirefighterAvailabilityViews.ResumeLayout();

            if (this.tableFirefighterAvailabilityViews.Controls.Count > 0)
            {
                this.currentControl = 0;
                this.panel.ScrollControlIntoView(this.tableFirefighterAvailabilityViews.Controls[0]);
            }

            this.timerAutoScroll.Start();
        }

        /// <summary>
        /// Called when the theme is updated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains no event data.</param>
        private void CurrentSetting_ThemeUpdated(object sender, EventArgs e)
        {
            this.ApplyTheme(((Core.Syst.Setting)sender).Theme);
        }

        /// <summary>
        /// Display the next control to be displayed. If there is no next, the next control is the first.
        /// </summary>
        /// <param name="sender">The object that launched the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void TimerAutoScroll_Tick(object sender, EventArgs e)
        {
            this.timerAutoScroll.Stop();

            int numObjectDisplayed = this.tableFirefighterAvailabilityViews.Controls.Cast<Control>().Where(c => c.Visible == true).Count();

            if (numObjectDisplayed > 0)
            {
                if (this.currentControl < numObjectDisplayed - 1)
                {
                    this.currentControl++;
                }
                else
                {
                    this.currentControl = 0;
                }

                this.panel.ScrollControlIntoView(this.tableFirefighterAvailabilityViews.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
    }
}
