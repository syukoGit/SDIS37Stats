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
        private readonly Core.Statistics.Operation operation;

        public DisplayOperation(Core.Statistics.Operation operation)
        {
            InitializeComponent();

            this.operation = operation;

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
