using System;

namespace SDIS37Stats.Core.Statistics
{
    public class FirefighterAvailability : IComparable
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

        public new string ToString()
        {
            return Rank + " / " + Name + " / " + Availability.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is FirefighterAvailability))
            {
                return 1;
            }

            int compareToValue = this.Availability.CompareTo((obj as FirefighterAvailability).Availability);

            if (compareToValue == 0)
            {
                return this.Name.CompareTo((obj as FirefighterAvailability).Name);
            }
            else
            {
                return compareToValue;
            }
        }
    }
}
