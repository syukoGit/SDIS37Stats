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

        private ToolTip webServiceStateToolTip = new();

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
            Core.Syst.Setting.CurrentSetting.PropertyChanged += this.Setting_PropertyChanged;

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
            this.webService.StateChanged += this.WebService_StateChanged;

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

        private void Setting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != null && sender is Core.Syst.Setting && sender == Core.Syst.Setting.CurrentSetting)
            {
                var prop = typeof(Core.Syst.Setting).GetProperty(e.PropertyName);

                switch (prop.Name)
                {
                    case "Theme":
                        this.ApplyTheme();
                        break;
                    case "MuteSound":
                        Extra.Sound.Sound.Mute = (bool)prop.GetValue(sender);
                        break;
                    case "NbOperationOfDepartmentDisplayed":
                        this.RecentOperationList.NbOperationDisplayed = (int)prop.GetValue(sender);
                        break;
                    case "NbOperationOfUserFirehouseDisplayed":
                        this.RecentOperationOfUserFirehouse.NbOperationDisplayed = (int)prop.GetValue(sender);
                        break;
                    case "NbFirefighterAvailabilityDisplayed":
                        this.FirefighterAvailabilityListView.NbAvailibilitiesDisplayed = (int)prop.GetValue(sender);
                        break;
                    default:
                        break;
                }
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
                List<Core.Statistics.Operation> operations = this.statistics.OperationList.Where(c => c.Time.Date == DateTime.Now.AddHours(-1).Date).ToList();
                Core.Statistics.Statistics.ExportOperationListToXml(operations, DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd"));
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

        private void WebService_StateChanged(object e, Core.Web.WebService.EState state)
        {
            switch (state)
            {
                case Core.Web.WebService.EState.NotStated:
                    this.webServiceState.Image = Extra.Image.Image.WebServiceState_NotStated;
                    this.webServiceStateToolTip.SetToolTip(this.webServiceState, "Pas démarré");
                    break;
                case Core.Web.WebService.EState.DataRetrieving:
                    this.webServiceState.Image = Extra.Image.Image.WebServiceState_DataRetrieving;
                    this.webServiceStateToolTip.SetToolTip(this.webServiceState, $"Récupération des données en cours ({ this.webService.CurrentUrl })");
                    break;
                case Core.Web.WebService.EState.UpToDate:
                    this.webServiceState.Image = Extra.Image.Image.WebServiceState_UpToDate;
                    this.webServiceStateToolTip.SetToolTip(this.webServiceState, "À jour");
                    break;
                case Core.Web.WebService.EState.AttemptConnection:
                    this.webServiceState.Image = Extra.Image.Image.WebServiceState_AttemptConnection;
                    this.webServiceStateToolTip.SetToolTip(this.webServiceState, "Tentative de connexion");
                    break;
                case Core.Web.WebService.EState.FailedConnection:
                    this.webServiceState.Image = Extra.Image.Image.WebServiceState_FailedConnection;
                    this.webServiceStateToolTip.SetToolTip(this.webServiceState, "Impossible de se connecter");
                    break;
            }
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

                Core.Syst.Setting.UpdateSettings(this.settingsForm.Settings);

                this.ApplyTheme();
            }
        }
        #endregion
    }
}
