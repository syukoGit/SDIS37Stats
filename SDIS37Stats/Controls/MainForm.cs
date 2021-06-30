//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Class for make the main form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Used for display the current webservice's state.
        /// </summary>
        private readonly ToolTip webServiceStateToolTip = new ();

        /// <summary>
        /// A <see cref="Core.Web.WebService"/> object used for connect to SDIS37's webservice.
        /// </summary>
        private Core.Web.WebService webService;

        /// <summary>
        /// A <see cref="Core.Statistics.Statistics"/> object used for get the firefighter's statistics.
        /// </summary>
        private Core.Statistics.Statistics statistics;

        /// <summary>
        /// Used for show a settings form.
        /// </summary>
        private SettingsForm settingsForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.ApplyTheme(Core.Syst.Setting.CurrentSetting.Theme);

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

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="WebBrowser"/> used in the <see cref="Core.Web.WebService"/> should be displayed.
        /// </summary>
        public bool ShowWebBrowser { get; set; } = false;

        /// <summary>
        /// Gets the interval in second with the next minute.
        /// </summary>
        /// <returns>The interval in second.</returns>
        private static int GetIntervalInSecondsWithNextMinute()
        {
            DateTime now = DateTime.Now;
            return ((60 - now.Second) * 1000) - now.Millisecond;
        }

        /// <summary>
        /// Initializes the event connections and the <see cref="Core.Web.WebService"/> of the <see cref="MainForm"/> class.
        /// </summary>
        private void Init()
        {
            Core.Syst.Setting.CurrentSetting.PropertyChanged += this.Setting_PropertyChanged;
            Core.Syst.Setting.CurrentSetting.ThemeUpdated += this.CurrentSetting_ThemeUpdated;

            this.SettingsPicture.Image = Extra.Image.Image.SettingsPicture;

            this.LastUpdate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            this.webService = new Core.Web.WebService();
            this.webService.UrlQueueEmpty += this.WebService_OnUrlQueueEmpty;
            this.webService.StateChanged += this.WebService_StateChanged;

            this.recentOperationOfUserFirehouse.OnlyOperationOfUserFirehouse = true;
            this.recentOperationOfUserFirehouse.NbOperationDisplayed = Core.Syst.Setting.CurrentSetting.NbOperationOfUserFirehouseDisplayed;

            this.recentOperationList.NbOperationDisplayed = Core.Syst.Setting.CurrentSetting.NbOperationOfDepartmentDisplayed;

            this.statistics = new Core.Statistics.Statistics(this.webService);

            this.statistics.NewOperation += this.Statistics_NewOperation;
            this.statistics.NewOperationOfUserFirehouse += this.Statistics_NewOperationOfUserFirehouse;

            this.firefighterAvailabilityListView.Statistics = this.statistics;
            this.recentOperationList.Statistics = this.statistics;
            this.recentOperationOfUserFirehouse.Statistics = this.statistics;
            this.nbOperationPerHour.Statistics = this.statistics;
            this.nbOperationToday.Statistics = this.statistics;
        }

        /// <summary>
        /// Apply the theme on the control.
        /// </summary>
        /// <param name="theme">The theme to be applied.</param>
        private void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor;
            this.ForeColor = theme.Form_FontColor;

            this.LastUpdate.ForeColor = theme.Form_FontColor;
        }

        /// <summary>
        /// Called when a new operation is added.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="operations">The <see cref="Core.Statistics.Operation"/> array that contains the new operations.</param>
        private void Statistics_NewOperation(object sender, Core.Statistics.Operation[] operations)
        {
            if (OperatingSystem.IsWindows())
            {
                Extra.Sound.Sound.PlaySoundOnlyWindows(Extra.Sound.Sound.ESoundType.NewOperationNotification);
            }
        }

        /// <summary>
        /// Called when a new operation of the user's firehouse is added.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="operations">The <see cref="Core.Statistics.Operation"/> array that contains the new operations.</param>
        private void Statistics_NewOperationOfUserFirehouse(object sender, Core.Statistics.Operation[] operations)
        {
            if (OperatingSystem.IsWindows())
            {
                Extra.Sound.Sound.PlaySoundOnlyWindows(Extra.Sound.Sound.ESoundType.NewOperationOfUserFirehouseNotification);
            }
        }

        /// <summary>
        /// Called when a property of the <see cref="Core.Syst.Setting"/> class is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="System.ComponentModel.PropertyChangedEventArgs"/> that contains the event data.</param>
        private void Setting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                var prop = typeof(Core.Syst.Setting).GetProperty(e.PropertyName);

                switch (prop.Name)
                {
                    case "MuteSound":
                        Extra.Sound.Sound.Mute = (bool)prop.GetValue(sender);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Called when the form is closed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="FormClosedEventArgs"/> that contains the event data.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webService?.Dispose();
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
        /// when a timer has finished counting.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();

            if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0)
            {
                List<Core.Statistics.Operation> operations = this.statistics.OperationList.Where(c => c.StartedDateTimeLocal.Date == DateTime.Now.AddHours(-1).Date).ToList();
                Core.Statistics.Statistics.ExportOperationListToXml(operations, DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd"));
                this.webService.ClearSession();
            }

            this.statistics.Refresh();

            this.LastUpdate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        /// <summary>
        /// Called when the url queue of the <see cref="Core.Web.WebService"/> class is empty.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains no data.</param>
        private void WebService_OnUrlQueueEmpty(object sender, EventArgs e)
        {
            this.timer.Interval = GetIntervalInSecondsWithNextMinute();
            this.timer.Start();
        }

        /// <summary>
        /// Called when the state of the <see cref="Core.Web.WebService"/> class is changed.
        /// </summary>
        /// <param name="e">The source of the event.</param>
        /// <param name="state">The new <see cref="Core.Web.WebService.EState"/> of the <see cref="Core.Web.WebService"/>.</param>
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
                    this.webServiceStateToolTip.SetToolTip(this.webServiceState, $"Récupération des données en cours ({this.webService.CurrentUrl})");
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
                case Core.Web.WebService.EState.NoConnection:
                    this.webServiceState.Image = Extra.Image.Image.WebServiceState_NoConnection;
                    this.webServiceStateToolTip.SetToolTip(this.webServiceState, "Aucune connexion");
                    break;
                case Core.Web.WebService.EState.Error:
                    this.webServiceState.Image = Extra.Image.Image.WebServiceState_Error;
                    this.webServiceStateToolTip.SetToolTip(this.webServiceState, "Erreur");
                    break;
            }
        }

        /// <summary>
        /// Called when the mouse's cursor enters on the setting picture.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void SettingsPicture_MouseEnter(object sender, EventArgs e)
        {
            this.SettingsPicture.BorderStyle = BorderStyle.FixedSingle;
            this.SettingsPicture.BackColor = Core.Syst.Setting.CurrentSetting.Theme.SettingsButton_BackgroundColorWhenSelected;
        }

        /// <summary>
        /// Called when the mouse's cursor leaves on the setting picture.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void SettingsPicture_MouseLeave(object sender, EventArgs e)
        {
            this.SettingsPicture.BorderStyle = BorderStyle.None;
            this.SettingsPicture.BackColor = Core.Syst.Setting.CurrentSetting.Theme.SettingsButton_DefaultBackgroundColor;
        }

        /// <summary>
        /// Called when the setting picture is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
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

        /// <summary>
        /// Called when the settings form is closing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="FormClosingEventArgs"/> that contains the event data.</param>
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.settingsForm.DialogResult == DialogResult.OK)
            {
                this.settingsForm.FormClosing -= this.SettingsForm_FormClosing;

                Core.Syst.Setting.UpdateSettings(this.settingsForm.Settings);
            }
        }

        /// <summary>
        /// Called when a key is pressed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
            }

            e.Handled = false;
        }
    }
}
