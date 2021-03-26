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
    public partial class OperationView : UserControl
    {
        private Core.Statistics.Operation operation;

        private readonly ToolTip toolTip = new();

        public OperationView()
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

                switch (this.operation.Type)
                {
                    case Core.Statistics.Operation.OperationType.SAP:
                        this.pictureBoxOperationType.Image = Extra.Image.Image.OperationType_SAP;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "SAP");
                        break;
                    case Core.Statistics.Operation.OperationType.OD:
                        this.pictureBoxOperationType.Image = Extra.Image.Image.OperationType_OD;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "OD");
                        break;
                    case Core.Statistics.Operation.OperationType.INC:
                        this.pictureBoxOperationType.Image = Extra.Image.Image.OperationType_INC;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "INC");
                        break;
                    case Core.Statistics.Operation.OperationType.OTHER:
                        this.pictureBoxOperationType.Image = Extra.Image.Image.OperationType_Other;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "Autre");
                        break;
                    default:
                        this.pictureBoxOperationType.Image = null;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "Error");
                        break;
                }

                this.vehicules.Text = string.Empty;
                foreach (var item in this.operation.VehiculeEnrolled)
                {
                    vehicules.Text += item + "\n";
                }
            }
        }
    }
}
