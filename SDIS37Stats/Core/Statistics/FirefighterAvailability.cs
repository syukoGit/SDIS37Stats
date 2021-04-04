using System;

namespace SDIS37Stats.Core.Statistics
{
    public class FirefighterAvailability : IComparable<FirefighterAvailability>
    {
        public enum AVAILABILITY
        {
            AvailableOnSite = 1,
            Available5Min = 2,
            Available10Min = 3,
            NotAvailable = 4,
            InIntervention = 0
        }

        public AVAILABILITY Availability { get; set; }

        public string Matricule { get; set; }

        public string Name { get; set; }

        public string Rank { get; set; }

        public override string ToString()
        {
            return Rank + " / " + Name + " / " + Availability.ToString();
        }

        public int CompareTo(FirefighterAvailability obj)
        {
            if (obj == null)
            {
                return 1;
            }

            int compareToValue = this.Availability.CompareTo(obj.Availability);

            if (compareToValue == 0)
            {
                return this.Name.CompareTo(obj.Name);
            }
            else
            {
                return compareToValue;
            }
        }
    }
}
