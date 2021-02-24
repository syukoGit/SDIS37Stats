using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIS37Stats.Controls
{
    public partial class GetCredentials : Form
    {
        public (string Username, string Password) Credentials
        {
            get
            {
                return (this.username.Text, this.password.Text);
            }
        }

        public GetCredentials()
        {
            InitializeComponent();

            this.BackColor = MainForm.Instance.Settings.Theme.Form_BackgroundColor();
            this.ForeColor = MainForm.Instance.Settings.Theme.Form_FontColor();

            this.buttonOk.BackColor = MainForm.Instance.Settings.Theme.Form_BackgroundColorButton();


            this.username.BackColor = MainForm.Instance.Settings.Theme.Form_BackgroundColorTextbox();
            this.username.ForeColor = MainForm.Instance.Settings.Theme.Form_FontColor();

            this.password.BackColor = MainForm.Instance.Settings.Theme.Form_BackgroundColorTextbox();
            this.password.ForeColor = MainForm.Instance.Settings.Theme.Form_FontColor();
        }

        #region Event

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _ = this.password.Focus();
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buttonOk.Focus();
            }
        }

        #endregion
    }
}
