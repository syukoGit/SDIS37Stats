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
            this.InitializeComponent();

            this.webService = new Core.Web.WebService();

            this.statistics = new Core.Statistics.Statistics(this.webService);

            this.statistics.OnNewOperation += this.Statistics_NewOperation;

            this.ParametersPicture.Image = Extra.Image.Image.SettingsPicture;

            this.SetEventConnection();

            if (this.ShowWebBrowser)
            {
                this.webService.WebBrowser.Location = new System.Drawing.Point(229, 81);
                this.webService.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
                this.webService.WebBrowser.Name = "webBrowser";
                this.webService.WebBrowser.Size = new System.Drawing.Size(290, 320);
                this.webService.WebBrowser.TabIndex = 3;

                this.Controls.Add(this.webService.WebBrowser);
            }

            this.timer.Start();
        }

        #region Private
        private void SetEventConnection()
        {
            // NbOperationToday
            this.statistics.OnTotalOperationInDayUpdated += (c) => this.NbOperationToday.Value = c;

            // NbOperationPerHour
            this.statistics.OnOperationPerHourUpdated += (c) => this.NbOperationPerHour.Value = c;

            // RecentOperationList
            this.statistics.OnRecentOperationListUpdated += (c) =>
            {
                var value = c.Select(t => t.Value).ToList();
                value.Sort((a, b) => b.Time.CompareTo(a.Time));
                this.RecentOperationList.SetValue(value);
            };

            // displayFirefighterAvailabilityList
            this.statistics.OnFirehouseNameUpdated += (c) => this.displayFirefighterAvailabilityList.Title = "Liste des disponibilités de " + c + " :";
            this.statistics.OnFirefighterAvailabilitiesUpdated += this.displayFirefighterAvailabilityList.SetValue;

            // RecentOperationOfUserFirehouse
            this.statistics.OnFirehouseNameUpdated += (c) => this.RecentOperationOfUserFirehouse.Title = "Liste des dernières interventions de " + c + " :";
            this.statistics.OnRecentOperationOfUserFirehouseUpdated += (c) =>
            {
                c.Sort((a, b) => b.Time.CompareTo(a.Time));
                this.RecentOperationOfUserFirehouse.SetValue(c);
            };
        }

        private static int GetIntervalInSecondsWithNextMinute()
        {
            DateTime now = DateTime.Now;
            return (60 - now.Second) * 1000 - now.Millisecond;
        }
        #endregion

        #region Event
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

            this.LastUpdate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            this.timer.Interval = GetIntervalInSecondsWithNextMinute();
            this.timer.Start();
        }
        
        private void SettingsPicture_MouseEnter(object sender, EventArgs e)
        {
            this.ParametersPicture.BorderStyle = BorderStyle.FixedSingle;
            this.ParametersPicture.BackColor = Theme.MainForm.SettingsButton_BackgroundColorWhenSelected;
        }

        private void SettingsPicture_MouseLeave(object sender, EventArgs e)
        {
            this.ParametersPicture.BorderStyle = BorderStyle.None;
            this.ParametersPicture.BackColor = Theme.MainForm.SettingsButton_DefaultBackgroundColor;
        }
        #endregion

        
    }
}
