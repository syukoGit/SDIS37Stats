namespace SDIS37Stats.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class SettingsForm : Form
    {
        private static readonly Dictionary<Core.Syst.Setting.THEMETYPE, string> themeTypeList = new Dictionary<Core.Syst.Setting.THEMETYPE, string>
        {
            { Core.Syst.Setting.THEMETYPE.Dark, "Mode sombre" },
            { Core.Syst.Setting.THEMETYPE.Light, "Mode clair" }
        };

        public Core.Syst.Setting Settings { get; private set; }

        public SettingsForm(Core.Syst.Setting currentSettings)
        {
            this.Settings = currentSettings.DeepCopy(); ;

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

            this.comboBoxThemeType.BackColor = theme.SettingsForm_ComboBox_BackgroundColor();

            this.checkBoxMuteSound.BackColor = theme.SettingsForm_CheckBox_BackgroundColor();
            this.checkBoxMuteSound.ForeColor = theme.Form_FontColor();
        }

        private void Init()
        {
            this.comboBoxThemeType.SelectedItem = SettingsForm.themeTypeList[this.Settings.ThemeType];

            this.checkBoxMuteSound.Checked = this.Settings.MuteSound;

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
