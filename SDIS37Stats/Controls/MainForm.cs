using System;
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

            this.statistics.OnStatUpdated += this.Statistics_StatUpdated;
            this.statistics.OnNewOperation += this.Statistics_NewOperation;

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
        private void Statistics_StatUpdated()
        {
            var recentOperationList = this.statistics.RecentOperationList.Select(c => c.Value).ToList();
            recentOperationList.Sort((a, b) => b.Time.CompareTo(a.Time));

            var recentOperationListOfUserFirehouse = this.statistics.RecentOperationOfUserFirehouse;
            recentOperationList.Sort((a, b) => b.Time.CompareTo(a.Time));

            this.NbOperationToday.Value = this.statistics.TotalOperationInDay;

            this.LastUpdate.Text = this.statistics.LastRefresh.ToString("dd/MM/yyyy HH:mm");

            this.NbOperationPerHour.Value = new List<int>(this.statistics.OperationPerHour);

            this.RecentOperationList.SetValue(recentOperationList);
            this.RecentOperationList.FirehouseName = this.statistics.FirehouseName;

            this.RecentOperationOfUserFirehouse.Title = "Liste des dernières interventions de " + this.statistics.FirehouseName + " :";
            this.RecentOperationOfUserFirehouse.SetValue(recentOperationListOfUserFirehouse);

            this.displayFirefighterAvailabilityList.Title = "Liste des disponibilités de " + this.statistics.FirehouseName + " :";
            this.displayFirefighterAvailabilityList.SetValue(this.statistics.FirefighterAvailabilities);

            this.timer.Interval = GetIntervalInSecondsWithNextMinute();
            this.timer.Start();
        }

        private void Statistics_NewOperation()
        {
            Extra.Sound.Sound.NewOperationNotification();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webService?.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();

            if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0)
            {
                this.webService.ClearSession();
            }

            this.webService.RefreshAllValue();
        }
        #endregion
    }
}
