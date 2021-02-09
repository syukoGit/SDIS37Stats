﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SDIS37Stats.Controls
{
    public partial class MainForm : Form
    {
        private readonly Core.Web.WebService webService;

        private readonly Core.Statistics.Statistics statistics;

        public bool ShowWebBrowser { get; set; } = false;

        public MainForm()
        {
            InitializeComponent();

            this.webService = new Core.Web.WebService();

            this.statistics = new Core.Statistics.Statistics(this.webService);

            this.statistics.OnStatUpdated += this.StatUpdated;

            if (this.ShowWebBrowser)
            {
                this.webService.WebBrowser.Location = new System.Drawing.Point(229, 81);
                this.webService.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
                this.webService.WebBrowser.Name = "webBrowser";
                this.webService.WebBrowser.Size = new System.Drawing.Size(290, 320);
                this.webService.WebBrowser.TabIndex = 3;

                this.Controls.Add(this.webService.WebBrowser);
            }
        }

        #region Private
        private static int GetIntervalInSecondsWithNextMinute()
        {
            DateTime now = DateTime.Now;
            return (60 - now.Second) * 1000 - now.Millisecond;
        }
        #endregion

        #region Event
        private void StatUpdated()
        {
            var recentOperationList = this.statistics.RecentOperationList.Select(c => c.Value).ToList();
            recentOperationList.Sort((a, b) => b.Time.CompareTo(a.Time));

            this.NbOperationToday.Value = this.statistics.TotalOperationInDay;
            this.LastUpdate.Text = this.statistics.LastRefresh.ToString("dd/MM/yyyy HH:mm");
            this.NbOperationPerHour.Value = new List<int>(this.statistics.OperationPerHour);
            this.RecentOperationList.SetValue(recentOperationList);
            this.RecentOperationList.FirehouseName = this.statistics.FirehouseName;

            this.timer.Interval = GetIntervalInSecondsWithNextMinute();
            this.timer.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webService.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.webService.Refresh();
        }
        #endregion
    }
}
