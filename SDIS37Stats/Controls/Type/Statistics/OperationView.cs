//-----------------------------------------------------------------------
// <copyright file="OperationView.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.Statistics
{
    using System.Windows.Forms;
    using SDIS37Stats.Core.Statistics;

    /// <summary>
    /// Class for display a <see cref="Core.Statistics.Operation"/>.
    /// </summary>
    public partial class OperationView : UserControl
    {
        /// <summary>
        /// <see cref="ToolTip"/> used for display the <see cref="Operation.EOperationType"/> of the <see cref="Core.Statistics.Operation"/>.
        /// </summary>
        private readonly ToolTip toolTip = new ();

        /// <summary>
        /// <see cref="Core.Statistics.Operation"/> to be displayed.
        /// </summary>
        private Operation operation;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationView"/> class.
        /// </summary>
        public OperationView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the <see cref="Core.Statistics.Operation"/> to be displayed.
        /// </summary>
        public Operation Operation
        {
            get => this.operation;
            set
            {
                this.operation = value;

                this.time.Text = this.operation.StartedDateTimeLocal.ToString("dd/MM/yyyy HH:mm");
                this.numOperation.Text = this.operation.NumOperation.ToString();
                this.localisation.Text = this.operation.Location;
                this.OperationDescription.Text = this.operation.OperationDescription;

                switch (this.operation.Type)
                {
                    case Operation.EOperationType.SAP:
                        this.pictureBoxOperationType.Image = Extra.Image.Image.OperationType_SAP;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "SAP");
                        break;
                    case Operation.EOperationType.OD:
                        this.pictureBoxOperationType.Image = Extra.Image.Image.OperationType_OD;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "OD");
                        break;
                    case Operation.EOperationType.INC:
                        this.pictureBoxOperationType.Image = Extra.Image.Image.OperationType_INC;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "INC");
                        break;
                    case Operation.EOperationType.OTHER:
                        this.pictureBoxOperationType.Image = Extra.Image.Image.OperationType_Other;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "Autre");
                        break;
                    default:
                        this.pictureBoxOperationType.Image = null;
                        this.toolTip.SetToolTip(this.pictureBoxOperationType, "Error");
                        break;
                }

                this.vehicules.Text = string.Empty;
                foreach (var item in this.operation.VehiclesTriggered)
                {
                    this.vehicules.Text += item + "\n";
                }
            }
        }
    }
}
