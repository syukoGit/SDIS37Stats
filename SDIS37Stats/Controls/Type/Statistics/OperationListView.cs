//-----------------------------------------------------------------------
// <copyright file="OperationListView.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Class for display the <see cref="OperationView"/> list.
    /// </summary>
    public partial class OperationListView : UserControl
    {
        /// <summary>
        /// List of <see cref="Core.Statistics.Operation"/> to be displayed.
        /// </summary>
        private readonly List<Core.Statistics.Operation> data = new ();

        /// <summary>
        /// Currently displayed control index.
        /// </summary>
        private int currentControl = 0;

        /// <summary>
        /// Maximum number of the <see cref="OperationView"/> to be displayed.
        /// </summary>
        private int numOperationDisplayed = 15;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationListView"/> class.
        /// </summary>
        public OperationListView()
        {
            this.InitializeComponent();

            Core.Syst.Setting.CurrentSetting.ThemeUpdated += this.CurrentSetting_ThemeUpdated;

            this.timerAutoScroll.Start();
        }

        /// <summary>
        /// Gets or sets the maximum number of the <see cref="OperationView"/> to be displayed.
        /// </summary>
        public int NbOperationDisplayed
        {
            get
            {
                return this.numOperationDisplayed;
            }

            set
            {
                this.numOperationDisplayed = value;

                this.SetOperationViews();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the operations of the user's firehouse need to be highlighted.
        /// </summary>
        public bool HighlightOperationOfUserFirehouse { get; set; } = false;

        /// <summary>
        /// Gets or sets the firehouse's name of the user.
        /// </summary>
        public string FirehouseName { get; set; } = null;

        /// <summary>
        /// Gets or sets the background's color of each not highlighted <see cref="OperationView"/>.
        /// </summary>
        public Color BackgroundColorItem { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the font's color of each not highlighted <see cref="OperationView"/>.
        /// </summary>
        public Color FontColorItem { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets the background's color of each highlighted <see cref="OperationView"/>.
        /// </summary>
        public Color BackgroundColorHighlightItem { get; set; } = Color.Red;

        /// <summary>
        /// Gets or sets the font's color of each highlighted <see cref="OperationView"/>.
        /// </summary>
        public Color FontColorHighLightItem { get; set; } = Color.Green;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get => this.title.Text;
            set => this.title.Text = value;
        }

        /// <summary>
        /// Apply a <see cref="Extra.Theme.ITheme"/> on this control.
        /// </summary>
        /// <param name="theme">A theme to be applied.</param>
        public void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.OperationListView_BackgroundColorList;
            this.ForeColor = theme.Form_FontColor;

            this.tableLayoutPanel.BackColor = theme.OperationListView_BackgroundColor;
            this.panel.BackColor = theme.OperationListView_BackgroundColorList;
            this.tableOperationViews.BackColor = theme.OperationListView_BackgroundColorList;

            this.title.ForeColor = theme.Form_FontColor;

            foreach (Control item in this.tableOperationViews.Controls)
            {
                if (this.HighlightOperationOfUserFirehouse && !string.IsNullOrWhiteSpace(this.FirehouseName) && (item as OperationView).Operation.VehiclesTriggered.Any(c => c.Contains(this.FirehouseName)))
                {
                    item.BackColor = theme.OperationListView_BackgroundColorHighlightItem;
                    item.ForeColor = theme.OperationListView_FontColorHighlightItem;
                }
                else
                {
                    item.BackColor = theme.OperationListView_BackgroundColorItem;
                    item.ForeColor = theme.OperationListView_FontColorItem;
                }
            }
        }

        /// <summary>
        /// Add a <see cref="Core.Statistics.Operation"/> list to the current data.
        /// </summary>
        /// <param name="operations">A <see cref="Core.Statistics.Operation"/> list to be added.</param>
        public void AddOperations(IEnumerable<Core.Statistics.Operation> operations)
        {
            this.data.AddRange(operations.Where(c => !this.data.Select(t => t.NumOperation).Contains(c.NumOperation)));

            this.SetOperationViews();
        }

        /// <summary>
        /// Add a <see cref="Core.Statistics.Operation"/> to the current data.
        /// </summary>
        /// <param name="operation">A <see cref="Core.Statistics.Operation"/> to be added.</param>
        public void AddOperation(Core.Statistics.Operation operation)
        {
            if (this.data.Any(c => c.NumOperation == operation.NumOperation))
            {
                this.data.Add(operation);
            }

            this.SetOperationViews();
        }

        /// <summary>
        /// Display the <see cref="FirefighterAvailabilityView"/> list.
        /// </summary>
        private void SetOperationViews()
        {
            this.timerAutoScroll.Stop();

            this.tableOperationViews.SuspendLayout();

            if (this.tableOperationViews.Controls.Count > this.numOperationDisplayed)
            {
                for (int i = this.tableOperationViews.Controls.Count - 1; i >= this.numOperationDisplayed || i >= this.data.Count; i--)
                {
                    var operationView = this.tableOperationViews.Controls[i];
                    this.tableOperationViews.Controls.Remove(operationView);
                    operationView?.Dispose();
                }
            }
            else
            {
                for (int i = this.tableOperationViews.Controls.Count; i < this.numOperationDisplayed && i < this.data.Count; i++)
                {
                    this.tableOperationViews.Controls.Add(new OperationView()
                    {
                        Dock = DockStyle.Fill,
                    });
                }
            }

            if (this.data != null && this.data.Any())
            {
                this.data.Sort((a, b) => b.StartedDateTimeLocal.CompareTo(a.StartedDateTimeLocal));

                System.Collections.IList controlList = this.tableOperationViews.Controls;
                for (int i = 0; i < controlList.Count; i++)
                {
                    OperationView operationView = (OperationView)controlList[i];

                    if (operationView.Operation != this.data[i])
                    {
                        operationView.Operation = this.data[i];
                    }
                }
            }

            this.ApplyTheme(Core.Syst.Setting.CurrentSetting.Theme);

            this.tableOperationViews.ResumeLayout();

            if (this.tableOperationViews.Controls.Count > 0)
            {
                this.currentControl = 0;
                this.panel.ScrollControlIntoView(this.tableOperationViews.Controls[0]);
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

            if (this.tableOperationViews.Controls.Count > 0)
            {
                if (this.currentControl < this.tableOperationViews.Controls.Count - 1)
                {
                    this.currentControl++;
                }
                else
                {
                    this.currentControl = 0;
                }

                this.panel.ScrollControlIntoView(this.tableOperationViews.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
    }
}
