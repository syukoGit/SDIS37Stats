using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDIS37Stats.Controls
{
    public partial class MainForm : Form
    {
        private readonly Core.Web.WebService webService;

        public MainForm()
        {
            InitializeComponent();

            var getCredentials = new GetCredentials();
            _ = getCredentials.ShowDialog();

            var (Username, Password) = getCredentials.Credentials;

            this.webService = new Core.Web.WebService(Username, Password);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.webService.Refresh();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webService.Dispose();
        }
    }
}
