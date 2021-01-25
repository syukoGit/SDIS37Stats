using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class NbOperationPerHour: UserControl
    {
        public NbOperationPerHour()
        {
            InitializeComponent();
        }

        public List<int> Value
        {
            get
            {
                return this.barGraph.Value;
            }

            set
            {
                if (value != null && value.Count == 24)
                {
                    this.barGraph.Value = value;
                }
            }
        }
    }
}
