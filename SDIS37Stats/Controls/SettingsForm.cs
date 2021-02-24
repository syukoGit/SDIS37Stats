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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            this.InitializeComponent();
        }

        #region Private
        private void Init()
        {
            var settings = (this.Owner as MainForm).Settings;

            this.checkBoxMuteSound.Checked = settings.MuteSound;
        }
        #endregion
    }
}
