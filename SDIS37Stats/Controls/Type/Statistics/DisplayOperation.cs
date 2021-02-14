using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class DisplayOperation : UserControl
    {
        private Core.Statistics.Operation operation;

        public DisplayOperation()
        {
            InitializeComponent();
        }

        public Core.Statistics.Operation Operation
        {
            get => this.operation;
            set
            {
                this.operation = value;

                this.time.Text = operation.Time.ToString("dd/MM/yyyy HH:mm");
                this.numOperation.Text = operation.NumOperation.ToString();
                this.localisation.Text = operation.Localisation;
                this.OperationDescription.Text = operation.OperationDescription;

                this.vehicules.Text = string.Empty;
                foreach (var item in this.operation.VehiculeEnrolled)
                {
                    vehicules.Text += item + "\n";
                }
            }
        }
    }
}
