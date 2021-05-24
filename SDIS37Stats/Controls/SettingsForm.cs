//-----------------------------------------------------------------------
// <copyright file="SettingsForm.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Class for make a form for change the <see cref="Core.Syst.Setting"/> properties.
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// A <see cref="Dictionary{TKey, TValue}"/> binding a <see cref="Extra.Theme.ITheme.EThemeType"/> and its nice name.
        /// The key is a <see cref="Extra.Theme.ITheme.EThemeType"/> and the value is a <see cref="string"/>.
        /// </summary>
        private static readonly Dictionary<Extra.Theme.ITheme.EThemeType, string> ThemeTypeList = new ()
        {
            { Extra.Theme.ITheme.EThemeType.Dark, "Mode sombre" },
            { Extra.Theme.ITheme.EThemeType.Light, "Mode clair" },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsForm"/> class.
        /// </summary>
        /// <param name="currentSettings">A <see cref="Core.Syst.Setting"/> to be copied.</param>
        public SettingsForm(Core.Syst.Setting currentSettings)
        {
            this.Settings = currentSettings.DeepCopy();

            this.InitializeComponent();

            this.comboBoxThemeType.DataSource = new BindingSource(SettingsForm.ThemeTypeList, null);
            this.comboBoxThemeType.DisplayMember = "Value";
            this.comboBoxThemeType.ValueMember = "Key";

            this.ApplyTheme(currentSettings.Theme);

            this.Init();
        }

        /// <summary>
        /// Gets a <see cref="Core.Syst.Setting"/> instance which will changed by the <see cref="SettingsForm"/>.
        /// </summary>
        public Core.Syst.Setting Settings { get; private set; }

        /// <summary>
        /// Initializes the event connections and the values o the controls.
        /// </summary>
        private void Init()
        {
            this.comboBoxThemeType.SelectedValue = this.Settings.Theme.ThemeType;

            this.checkBoxMuteSound.Checked = !this.Settings.MuteSound;

            this.nbOperationOfDepartmentDisplayed.Value = this.Settings.NbOperationOfDepartmentDisplayed;
            this.nbOperationOfUserFirehouseDisplayed.Value = this.Settings.NbOperationOfUserFirehouseDisplayed;

            this.nbFirefighterAvailabilityDisplayed.Value = this.Settings.NbFirefighterAvailabilityDisplayed;

            // Event connection
            this.comboBoxThemeType.SelectedIndexChanged += this.ComboBoxThemeType_SelectedIndexChanged;
        }

        /// <summary>
        /// Apply a theme on the control.
        /// </summary>
        /// <param name="theme">A <see cref="Extra.Theme.ITheme"/> to be applied.</param>
        private void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor;
            this.ForeColor = theme.Form_FontColor;

            this.buttonOk.BackColor = theme.Form_BackgroundColorButton;
            this.buttonCancel.BackColor = theme.Form_BackgroundColorButton;

            this.groupBoxFirefighterAvailability.ForeColor = theme.Form_FontColor;
            this.groupBoxOperationView.ForeColor = theme.Form_FontColor;
            this.groupBoxSound.ForeColor = theme.Form_FontColor;
            this.groupBoxThemeAndColor.ForeColor = theme.Form_FontColor;

            this.comboBoxThemeType.BackColor = theme.SettingsForm_ComboBox_BackgroundColor;

            this.checkBoxMuteSound.ForeColor = theme.Form_FontColor;

            this.labelNbOperationOfDepartmentDisplayed.ForeColor = theme.Form_FontColor;
            this.nbOperationOfDepartmentDisplayed.BackColor = theme.Form_BackgroundColorTextbox;
            this.nbOperationOfDepartmentDisplayed.ForeColor = theme.Form_FontColor;

            this.labelNbOperationOfUserFirehouseDisplayed.ForeColor = theme.Form_FontColor;
            this.nbOperationOfUserFirehouseDisplayed.BackColor = theme.Form_BackgroundColorTextbox;
            this.nbOperationOfUserFirehouseDisplayed.ForeColor = theme.Form_FontColor;

            this.labelNbFirefighterAvailabilityDisplayed.ForeColor = theme.Form_FontColor;
            this.nbFirefighterAvailabilityDisplayed.BackColor = theme.Form_BackgroundColorTextbox;
            this.nbFirefighterAvailabilityDisplayed.ForeColor = theme.Form_FontColor;
        }

        /// <summary>
        /// Called when the selected theme is changed.
        /// </summary>
        /// <param name="sender">The source the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void ComboBoxThemeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((KeyValuePair<Extra.Theme.ITheme.EThemeType, string>)this.comboBoxThemeType.SelectedItem).Key)
            {
                case Extra.Theme.ITheme.EThemeType.Dark:
                    this.Settings.Theme = new Extra.Theme.DarkTheme();
                    break;
                case Extra.Theme.ITheme.EThemeType.Light:
                    this.Settings.Theme = new Extra.Theme.LightTheme();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Called when the mute sound's checkbox is checked or not.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void CheckBoxMuteSound_CheckedChanged(object sender, EventArgs e)
        {
            this.Settings.MuteSound = !this.checkBoxMuteSound.Checked;
            this.checkBoxMuteSound.Text = this.checkBoxMuteSound.Checked ? "Son activé" : "Son désactivé";
        }

        /// <summary>
        /// Called when the maximum number of the operations to be displayed is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void NbOperationOfDepartmentDisplayed_ValueChanged(object sender, EventArgs e)
        {
            this.Settings.NbOperationOfDepartmentDisplayed = (int)this.nbOperationOfDepartmentDisplayed.Value;
        }

        /// <summary>
        /// Called when the maximum number of the operations of the user's firehouse to be displayed is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void NbOperationOfUserFirehouseDisplayed_ValueChanged(object sender, EventArgs e)
        {
            this.Settings.NbOperationOfUserFirehouseDisplayed = (int)this.nbOperationOfUserFirehouseDisplayed.Value;
        }

        /// <summary>
        /// Called when the maximum number of the firefighter availabilities to be displayed is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void NbFirefighterAvailabilityDisplayed_ValueChanged(object sender, EventArgs e)
        {
            this.Settings.NbFirefighterAvailabilityDisplayed = (int)this.nbFirefighterAvailabilityDisplayed.Value;
        }

        /// <summary>
        /// Called when the OK button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        /// <summary>
        /// Called when the cancel button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
