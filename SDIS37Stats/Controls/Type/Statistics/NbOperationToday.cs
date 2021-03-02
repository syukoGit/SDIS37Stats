using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class NbOperationToday : UserControl
    {
        public int Value
        {
            get
            {
                return this.sevenSegmentArray1.Value;
            }

            set
            {
                this.sevenSegmentArray1.Value = value;
            }
        }

        public NbOperationToday()
        {
            InitializeComponent();
        }

        public void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor();
            this.ForeColor = theme.Form_FontColor();

            this.fix_label.ForeColor = theme.Form_FontColor();

            this.sevenSegmentArray1.ColorBackground = theme.Form_BackgroundColor();
            this.sevenSegmentArray1.ColorDark = theme.SevenSegment_DarkColor();
            this.sevenSegmentArray1.ColorLight = theme.SevenSegment_LightColor();
        }
    }
}
