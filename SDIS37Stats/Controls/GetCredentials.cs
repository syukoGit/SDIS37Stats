//-----------------------------------------------------------------------
// <copyright file="GetCredentials.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class for make a form for get the credentials.
    /// </summary>
    public partial class GetCredentials : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCredentials"/> class.
        /// </summary>
        public GetCredentials()
        {
            this.InitializeComponent();

            this.BackColor = Core.Syst.Setting.CurrentSetting.Theme.Form_BackgroundColor;
            this.ForeColor = Core.Syst.Setting.CurrentSetting.Theme.Form_FontColor;

            this.buttonOk.BackColor = Core.Syst.Setting.CurrentSetting.Theme.Form_BackgroundColorButton;

            this.username.BackColor = Core.Syst.Setting.CurrentSetting.Theme.Form_BackgroundColorTextbox;
            this.username.ForeColor = Core.Syst.Setting.CurrentSetting.Theme.Form_FontColor;

            this.password.BackColor = Core.Syst.Setting.CurrentSetting.Theme.Form_BackgroundColorTextbox;
            this.password.ForeColor = Core.Syst.Setting.CurrentSetting.Theme.Form_FontColor;
        }

        /// <summary>
        /// Gets the entered credentials by the user.
        /// </summary>
        public (string Username, string Password) Credentials
        {
            get
            {
                return (this.username.Text, this.password.Text);
            }
        }

        /// <summary>
        /// Called when the OK button is clicked.
        /// </summary>
        /// <param name="sender">The object which launched the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Called when a key is pressed while the control has focus.
        /// </summary>
        /// <param name="sender">The object which launched the event.</param>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _ = this.password.Focus();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Called when a key is pressed while the control has focus.
        /// </summary>
        /// <param name="sender">The object which launched the event.</param>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _ = this.buttonOk.Focus();
                e.Handled = true;
            }
        }
    }
}
