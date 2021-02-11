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

            switch (this.firefighterAvailability.Availability)
            {
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.AvailableOnSite:
                    this.labelAvailabitily.Text = "Disponible";
                    break;
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.Available5Min:
                    this.labelAvailabitily.Text = "Disponible en bleu";
                    break;
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.Available10Min:
                    this.labelAvailabitily.Text = "Disponible en violet";
                    break;
                case Core.Statistics.FirefighterAvailability.AVAILABILITY.NotAvailable:
                    this.labelAvailabitily.Text = "Indisponible";
                    break;
                default:
                    this.labelAvailabitily.Text = "Erreur";
                    break;
            }

            this.labelRank.Text = this.firefighterAvailability.Rank;
            this.labelName.Text = this.firefighterAvailability.Name;
        }
    }
}
