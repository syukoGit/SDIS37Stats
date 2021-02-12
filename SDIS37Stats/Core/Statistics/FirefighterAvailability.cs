namespace SDIS37Stats.Core.Statistics
{
    public class FirefighterAvailability
    {
        public enum AVAILABILITY
        {
            AvailableOnSite,
            Available5Min,
            Available10Min,
            NotAvailable,
            InIntervention
        }

        public AVAILABILITY Availability { get; set; }

        public string Matricule { get; set; }

        public string Name { get; set; }

        public string Rank { get; set; }

        public new string ToString()
        {
            return Rank + " / " + Name + " / " + Availability.ToString();
        }
    }
}
