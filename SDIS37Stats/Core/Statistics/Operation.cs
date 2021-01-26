using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS37Stats.Core.Statistics
{
    public class Operation
    {
        public enum OperationType
        {
            SAP,
            OD,
            INC,
            OTHER
        }

        public DateTime Time { get; set; }
        public int NumOperation { get; set; }
        public OperationType Type { get; set; }
        public string Localisation { get; set; }
        public string OperationDescription { get; set; }
        public HashSet<string> VehiculeEnrolled { get; set; }
    }
}
