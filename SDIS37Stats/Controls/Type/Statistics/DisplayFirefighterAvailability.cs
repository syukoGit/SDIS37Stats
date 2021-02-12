using System.Windows.Forms;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class DisplayFirefighterAvailability : UserControl
    {
        public Core.Statistics.FirefighterAvailability firefighterAvailability;

        public DisplayFirefighterAvailability(Core.Statistics.FirefighterAvailability firefighterAvailability)
        {
            InitializeComponent();

            this.firefighterAvailability = firefighterAvailability;

            var toolTip = new ToolTip();

            switch (this.firefighterAvailability.Availability)
            {
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.AvailableOnSite:
                    this.pictureBoxAvailability.Image = Extra.Image.Image.AvailableOnSite;
                    toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible sur site");
                    break;
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.Available5Min:
                    this.pictureBoxAvailability.Image = Extra.Image.Image.Available5min;
                    toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible 5 min");
                    break;
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.Available10Min:
                    this.pictureBoxAvailability.Image = Extra.Image.Image.Available10min;
                    toolTip.SetToolTip(this.pictureBoxAvailability, "Disponible 10 min");
                    break;
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.NotAvailable:
                    this.pictureBoxAvailability.Image = Extra.Image.Image.NotAvailableImage;
                    toolTip.SetToolTip(this.pictureBoxAvailability, "Indisponible");
                    break;
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.InIntervention:
                    this.pictureBoxAvailability.Image = Extra.Image.Image.InIntervention;
                    toolTip.SetToolTip(this.pictureBoxAvailability, "En intervention");
                    break;
                default:
                    this.pictureBoxAvailability.Image = null;
                    toolTip.SetToolTip(this.pictureBoxAvailability, "Erreur");
                    break;
            }

            this.labelRank.Text = this.firefighterAvailability.Rank;
            this.labelName.Text = this.firefighterAvailability.Name;
        }
    }
}
