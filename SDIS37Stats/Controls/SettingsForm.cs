namespace SDIS37Stats.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class SettingsForm : Form
    {
        private static readonly Dictionary<Core.Syst.Setting.THEMETYPE, string> themeTypeList = new()
        {
            { Core.Syst.Setting.THEMETYPE.Dark, "Mode sombre" },
            { Core.Syst.Setting.THEMETYPE.Light, "Mode clair" }
        };

        public Core.Syst.Setting Settings { get; private set; }

        public SettingsForm(Core.Syst.Setting currentSettings)
        {
            this.Settings = currentSettings.DeepCopy();

            this.InitializeComponent();

            this.comboBoxThemeType.DataSource = new BindingSource(SettingsForm.themeTypeList, null);
            this.comboBoxThemeType.DisplayMember = "Value";
            this.comboBoxThemeType.ValueMember = "Key";

            this.ApplyTheme(currentSettings.Theme);

            this.Init();
        }

        #region Private
        private void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor();
            this.ForeColor = theme.Form_FontColor();

            this.buttonOk.BackColor = theme.Form_BackgroundColorButton();
            this.buttonCancel.BackColor = theme.Form_BackgroundColorButton();

            this.groupBoxFirefighterAvailability.ForeColor = theme.Form_FontColor();
            this.groupBoxOperationView.ForeColor = theme.Form_FontColor();
            this.groupBoxSound.ForeColor = theme.Form_FontColor();
            this.groupBoxThemeAndColor.ForeColor = theme.Form_FontColor();

            this.comboBoxThemeType.BackColor = theme.SettingsForm_ComboBox_BackgroundColor();

            this.checkBoxMuteSound.ForeColor = theme.Form_FontColor();

            this.labelNbOperationOfDepartmentDisplayed.ForeColor = theme.Form_FontColor();
            this.nbOperationOfDepartmentDisplayed.BackColor = theme.Form_BackgroundColorTextbox();
            this.nbOperationOfDepartmentDisplayed.ForeColor = theme.Form_FontColor();

            this.labelNbOperationOfUserFirehouseDisplayed.ForeColor = theme.Form_FontColor();
            this.nbOperationOfUserFirehouseDisplayed.BackColor = theme.Form_BackgroundColorTextbox();
            this.nbOperationOfUserFirehouseDisplayed.ForeColor = theme.Form_FontColor();

            this.labelNbFirefighterAvailabilityDisplayed.ForeColor = theme.Form_FontColor();
            this.nbFirefighterAvailabilityDisplayed.BackColor = theme.Form_BackgroundColorTextbox();
            this.nbFirefighterAvailabilityDisplayed.ForeColor = theme.Form_FontColor();
        }

        private void Init()
        {
            this.comboBoxThemeType.SelectedValue = this.Settings.ThemeType;

            this.checkBoxMuteSound.Checked = !this.Settings.MuteSound;

            this.nbOperationOfDepartmentDisplayed.Value = this.Settings.NbOperationOfDepartmentDisplayed;
            this.nbOperationOfUserFirehouseDisplayed.Value = this.Settings.NbOperationOfUserFirehouseDisplayed;

            this.nbFirefighterAvailabilityDisplayed.Value = this.Settings.NbFirefighterAvailabilityDisplayed;

            //Event connection
            this.comboBoxThemeType.SelectedIndexChanged += this.ComboBoxThemeType_SelectedIndexChanged;
        }
        #endregion

        #region Event
        private void ComboBoxThemeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Settings.ThemeType = ((KeyValuePair<Core.Syst.Setting.THEMETYPE, string>)this.comboBoxThemeType.SelectedItem).Key;

            switch (this.Settings.ThemeType)
            {
                case Core.Syst.Setting.THEMETYPE.Dark:
                    this.Settings.Theme = new Extra.Theme.DarkTheme();
                    break;
                case Core.Syst.Setting.THEMETYPE.Light:
                    this.Settings.Theme = new Extra.Theme.LightTheme();
                    break;
                default:
                    break;
            }
        }

        private void CheckBoxMuteSound_CheckedChanged(object sender, EventArgs e)
        {
            this.Settings.MuteSound = !this.checkBoxMuteSound.Checked;
            this.checkBoxMuteSound.Text = this.checkBoxMuteSound.Checked ? "Son activé" : "Son désactivé";
        }

        private void NbOperationOfDepartmentDisplayed_ValueChanged(object sender, EventArgs e)
        {
            this.Settings.NbOperationOfDepartmentDisplayed = (int)this.nbOperationOfDepartmentDisplayed.Value;
        }

        private void NbOperationOfUserFirehouseDisplayed_ValueChanged(object sender, EventArgs e)
        {
            this.Settings.NbOperationOfUserFirehouseDisplayed = (int)this.nbOperationOfUserFirehouseDisplayed.Value;
        }

        private void NbFirefighterAvailabilityDisplayed_ValueChanged(object sender, EventArgs e)
        {
            this.Settings.NbFirefighterAvailabilityDisplayed = (int)this.nbFirefighterAvailabilityDisplayed.Value;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
        #endregion
    }
}
