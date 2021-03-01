using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SDIS37Stats.Controls
{
    public partial class MainForm : Form
    {
        private Core.Web.WebService webService;

        private Core.Statistics.Statistics statistics;

        private SettingsForm settingsForm;

        public static MainForm Instance { get; private set; }

        public Core.Syst.Setting Settings { get; set; } = new Core.Syst.Setting();

        public bool ShowWebBrowser { get; set; } = false;

        public delegate void OnThemeUpdatedHandler(Extra.Theme.ITheme theme);
        public event OnThemeUpdatedHandler OnThemeUpdated;

        public MainForm()
        {
            MainForm.Instance = this;

            this.InitializeComponent();

            this.Init();

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
        private void Init()
        {
            this.SettingsPicture.Image = Extra.Image.Image.SettingsPicture;

            //Event connection
            this.OnThemeUpdated += this.NbOperationToday.ApplyTheme;
            this.OnThemeUpdated += this.NbOperationPerHour.ApplyTheme;
            this.OnThemeUpdated += this.RecentOperationList.ApplyTheme;
            this.OnThemeUpdated += this.RecentOperationOfUserFirehouse.ApplyTheme;
            this.OnThemeUpdated += this.displayFirefighterAvailabilityList.ApplyTheme;

            this.ApplyTheme();

            this.webService = new Core.Web.WebService();

            this.statistics = new Core.Statistics.Statistics(this.webService);

            this.statistics.OnNewOperation += this.Statistics_NewOperation;

            this.SetStatisticEventConnection();
        }

        private void ApplyTheme()
        {
            this.BackColor = this.Settings.Theme.Form_BackgroundColor();
            this.ForeColor = this.Settings.Theme.Form_FontColor();

            this.LastUpdate.ForeColor = this.Settings.Theme.Form_FontColor();

            this.OnThemeUpdated?.Invoke(this.Settings.Theme);
        }

        private void SetStatisticEventConnection()
        {
            // NbOperationToday
            this.statistics.OnTotalOperationInDayUpdated += (c) => this.NbOperationToday.Value = c;

            // NbOperationPerHour
            this.statistics.OnOperationPerHourUpdated += (c) => this.NbOperationPerHour.Value = c;

            // RecentOperationList
            this.statistics.OnFirehouseNameUpdated += (c) => this.RecentOperationList.FirehouseName = c;
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
            Extra.Sound.Sound.PlaySound(Extra.Sound.Sound.SoundType.NewOperationNotification);
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
            this.SettingsPicture.BorderStyle = BorderStyle.FixedSingle;
            this.SettingsPicture.BackColor = this.Settings.Theme.SettingsButton_BackgroundColorWhenSelected();
        }

        private void SettingsPicture_MouseLeave(object sender, EventArgs e)
        {
            this.SettingsPicture.BorderStyle = BorderStyle.None;
            this.SettingsPicture.BackColor = this.Settings.Theme.SettingsButton_DefaultBackgroundColor();
        }

        private void SettingsPicture_Click(object sender, EventArgs e)
        {
            if (this.settingsForm != null)
            {
                this.settingsForm.Dispose();
            }

            this.settingsForm = new SettingsForm(this.Settings);
            this.settingsForm.FormClosing += this.SettingsForm_FormClosing;

            this.settingsForm.Show(this);
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.settingsForm.DialogResult == DialogResult.OK)
            {
                this.settingsForm.FormClosing -= this.SettingsForm_FormClosing;

                this.Settings = this.settingsForm.Settings;

                this.RecentOperationList.NbOperationDisplayed = this.Settings.NbOperationOfDepartmentDisplayed;

                this.RecentOperationOfUserFirehouse.NbOperationDisplayed = this.Settings.NbOperationOfUserFirehouseDisplayed;

                this.ApplyTheme();
            }
        }
        #endregion
    }
}
