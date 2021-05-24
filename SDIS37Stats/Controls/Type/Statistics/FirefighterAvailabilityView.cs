//-----------------------------------------------------------------------
// <copyright file="FirefighterAvailabilityView.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.Statistics
{
    using System.Windows.Forms;
    using SDIS37Stats.Core.Statistics;

    /// <summary>
    /// Class for make the <see cref="Core.Statistics.FirefighterAvailability"/> view.
    /// </summary>
    public partial class FirefighterAvailabilityView : UserControl
    {
        /// <summary>
        /// <see cref="ToolTip"/> used for display the <see cref="FirefighterAvailability.EAvailability"/> of the <see cref="Core.Statistics.FirefighterAvailability"/>.
        /// </summary>
        private readonly ToolTip toolTip = new ();

        /// <summary>
        /// <see cref="Core.Statistics.FirefighterAvailability"/> to be displayed.
        /// </summary>
        private FirefighterAvailability firefighterAvailability;

        /// <summary>
        /// Initializes a new instance of the <see cref="FirefighterAvailabilityView"/> class.
        /// </summary>
        public FirefighterAvailabilityView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the <see cref="Core.Statistics.FirefighterAvailability"/> to be displayed.
        /// </summary>
        public FirefighterAvailability FirefighterAvailability
        {
            get => this.firefighterAvailability;
            set
            {
                this.firefighterAvailability = value;

                if (this.firefighterAvailability != null)
                {
                    switch (this.FirefighterAvailability.Availability)
                    {
                        case FirefighterAvailability.EAvailability.AvailableOnSite:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.FirefighterAvailability_AvailableOnSite;
                            this.toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible sur site");
                            break;
                        case FirefighterAvailability.EAvailability.Available5Min:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.FirefighterAvailability_Available5min;
                            this.toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible 5 min");
                            break;
                        case FirefighterAvailability.EAvailability.Available10Min:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.FirefighterAvailability_Available10min;
                            this.toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible 10 min");
                            break;
                        case FirefighterAvailability.EAvailability.NotAvailable:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.FirefighterAvailability_NotAvailable;
                            this.toolTip.SetToolTip(this.pictureBoxAvailability, "Indisponible");
                            break;
                        case FirefighterAvailability.EAvailability.InIntervention:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.FirefighterAvailability_InIntervention;
                            this.toolTip.SetToolTip(this.pictureBoxAvailability, "En intervention");
                            break;
                        default:
                            this.pictureBoxAvailability.Image = null;
                            this.toolTip.SetToolTip(this.pictureBoxAvailability, "Erreur");
                            break;
                    }

                    this.labelRank.Text = this.FirefighterAvailability.Rank;
                    this.labelName.Text = this.FirefighterAvailability.Name;
                }
            }
        }
    }
}
