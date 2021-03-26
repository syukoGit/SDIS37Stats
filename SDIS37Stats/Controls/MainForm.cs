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

        public bool ShowWebBrowser { get; set; } = false;

        public delegate void OnThemeUpdatedHandler(Extra.Theme.ITheme theme);
        public event OnThemeUpdatedHandler OnThemeUpdated;

        public MainForm()
        {
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
            this.OnThemeUpdated += this.FirefighterAvailabilityListView.ApplyTheme;

            this.ApplyTheme();

            this.webService = new Core.Web.WebService();
            this.webService.OnUrlQueueEmpty += this.WebService_OnUrlQueueEmpty;

            this.statistics = new Core.Statistics.Statistics(this.webService);

            this.statistics.OnNewOperation += this.Statistics_NewOperation;
            this.statistics.OnNewOperationOfUserFirehouse += this.Statistics_NewOperationOfUserFirehouse;

            this.SetStatisticEventConnection();
        }

        private void ApplyTheme()
        {
            this.BackColor = Core.Syst.Setting.CurrentSetting.Theme.Form_BackgroundColor();
            this.ForeColor = Core.Syst.Setting.CurrentSetting.Theme.Form_FontColor();

            this.LastUpdate.ForeColor = Core.Syst.Setting.CurrentSetting.Theme.Form_FontColor();

            this.OnThemeUpdated?.Invoke(Core.Syst.Setting.CurrentSetting.Theme);
        }

        private void SetStatisticEventConnection()
        {
            // NbOperationToday
            this.statistics.OnTotalOperationInDayUpdated += (c) => this.NbOperationToday.Value = c;

            // NbOperationPerHour
            this.statistics.OnOperationPerHourUpdated += (c) => this.NbOperationPerHour.Value = c;

            // RecentOperationList
            this.statistics.OnFirehouseNameUpdated += (c) => this.RecentOperationList.FirehouseName = c;
            this.statistics.OnOperationListUpdated += (c) =>
            {
                var value = c.Where(t => t.Time.Date == DateTime.Now.Date).ToList();
                value.Sort((a, b) => b.Time.CompareTo(a.Time));
                this.RecentOperationList.AddOperations(value);
            };

            // FirefighterAvailabilityListView
            this.statistics.OnFirehouseNameUpdated += (c) => this.FirefighterAvailabilityListView.Title = "Liste des disponibilités de " + c + " :";
            this.statistics.OnFirefighterAvailabilitiesUpdated += this.FirefighterAvailabilityListView.SetFirefighterAvailabilities;

            // RecentOperationOfUserFirehouse
            this.statistics.OnFirehouseNameUpdated += (c) => this.RecentOperationOfUserFirehouse.Title = "Liste des dernières interventions de " + c + " :";
            this.statistics.OnOperationListOfUserFirehouseUpdated += (c) =>
            {
                var value = c.Where(t => t.Time.Date == DateTime.Now.Date).ToList();
                value.Sort((a, b) => b.Time.CompareTo(a.Time));
                this.RecentOperationOfUserFirehouse.AddOperations(value);
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
            if (OperatingSystem.IsWindows())
            {
                Extra.Sound.Sound.PlaySoundOnlyWindows(Extra.Sound.Sound.SoundType.NewOperationNotification);
            }
        }

        private void Statistics_NewOperationOfUserFirehouse()
        {
            if (OperatingSystem.IsWindows())
            {
                Extra.Sound.Sound.PlaySoundOnlyWindows(Extra.Sound.Sound.SoundType.NewOperationOfUserFirehouseNotification);
            }
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

            this.statistics.Refresh();

            this.LastUpdate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void WebService_OnUrlQueueEmpty()
        {
            this.timer.Interval = GetIntervalInSecondsWithNextMinute();
            this.timer.Start();
        }

        private void SettingsPicture_MouseEnter(object sender, EventArgs e)
        {
            this.SettingsPicture.BorderStyle = BorderStyle.FixedSingle;
            this.SettingsPicture.BackColor = Core.Syst.Setting.CurrentSetting.Theme.SettingsButton_BackgroundColorWhenSelected();
        }

        private void SettingsPicture_MouseLeave(object sender, EventArgs e)
        {
            this.SettingsPicture.BorderStyle = BorderStyle.None;
            this.SettingsPicture.BackColor = Core.Syst.Setting.CurrentSetting.Theme.SettingsButton_DefaultBackgroundColor();
        }

        private void SettingsPicture_Click(object sender, EventArgs e)
        {
            if (this.settingsForm != null)
            {
                this.settingsForm.Dispose();
            }

            this.settingsForm = new SettingsForm(Core.Syst.Setting.CurrentSetting);
            this.settingsForm.FormClosing += this.SettingsForm_FormClosing;

            this.settingsForm.Show(this);
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.settingsForm.DialogResult == DialogResult.OK)
            {
                this.settingsForm.FormClosing -= this.SettingsForm_FormClosing;

                Core.Syst.Setting.CurrentSetting = this.settingsForm.Settings;

                this.ApplyTheme();
            }
        }
        #endregion
    }
}
