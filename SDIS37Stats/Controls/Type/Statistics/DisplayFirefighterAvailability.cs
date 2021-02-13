using SDIS37Stats.Core.Statistics;
using System.Windows.Forms;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class DisplayFirefighterAvailability : UserControl
    {
        private FirefighterAvailability firefighterAvailability;

        private readonly ToolTip toolTip = new ToolTip();

        public DisplayFirefighterAvailability()
        {
            InitializeComponent();
        }

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
                        case FirefighterAvailability.AVAILABILITY.AvailableOnSite:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.AvailableOnSite;
                            toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible sur site");
                            break;
                        case FirefighterAvailability.AVAILABILITY.Available5Min:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.Available5min;
                            toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible 5 min");
                            break;
                        case FirefighterAvailability.AVAILABILITY.Available10Min:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.Available10min;
                            toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible 10 min");
                            break;
                        case FirefighterAvailability.AVAILABILITY.NotAvailable:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.NotAvailableImage;
                            toolTip.SetToolTip(this.pictureBoxAvailability, "Indisponible");
                            break;
                        case FirefighterAvailability.AVAILABILITY.InIntervention:
                            this.pictureBoxAvailability.Image = Extra.Image.Image.InIntervention;
                            toolTip.SetToolTip(this.pictureBoxAvailability, "En intervention");
                            break;
                        default:
                            this.pictureBoxAvailability.Image = null;
                            toolTip.SetToolTip(this.pictureBoxAvailability, "Erreur");
                            break;
                    }

                    this.labelRank.Text = this.FirefighterAvailability.Rank;
                    this.labelName.Text = this.FirefighterAvailability.Name;
                }
            }
        }
    }
}
