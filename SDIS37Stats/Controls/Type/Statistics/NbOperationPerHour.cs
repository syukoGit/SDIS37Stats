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

        #region Public
        public void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor();
            this.ForeColor = theme.Form_FontColor();

            this.fix_label.ForeColor = theme.Form_FontColor();

            this.barGraph.BackGroundColor = theme.Graph_BackgroundColor();
            this.barGraph.AxisColor = theme.Graph_AxisColor();
            this.barGraph.MainBarColor = theme.Graph_MainColor();
            this.barGraph.ValueColor = theme.Form_FontColor();
        }
        #endregion
    }
}
