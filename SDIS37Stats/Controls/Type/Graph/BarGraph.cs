using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Linq;

namespace SDIS37Stats.Controls.Type.Graph
{
    public partial class BarGraph : UserControl
    {
        private int gridHeight = 96;
        private readonly int gridWidth = 116;

        private List<int> value = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public BarGraph()
        {
            this.InitializeComponent();

            this.SuspendLayout();
            this.Name = "BarGraph";
            this.Paint += this.Graph_Paint;
            this.Resize += this.Graph_Resize;
            this.ResumeLayout(false);

            this.TabStop = false;
            this.DoubleBuffered = true;
        }

        public List<int> Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value != null)
                {
                    this.gridHeight = this.value.Count * 4;
                    this.value = value;
                    this.Invalidate();
                }
            }
        }

        public Color BackGroundColor { get; set; } = Theme.Graph.BackgroundColor;

        public Color AxisColor { get; set; } = Theme.Graph.AxisColor;

        public Color MainBarColor { get; set; } = Theme.Graph.MainBarColor;

        public Color ValueColor { get; set; } = Theme.Default.FontColor;

        #region Event
        private void Graph_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackGroundColor);
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Invalidate();
        }

        private void Graph_Paint(object sender, PaintEventArgs e)
        {
            Brush brushBar = new SolidBrush(this.MainBarColor);
            Brush brushFont = new SolidBrush(this.ValueColor);

            RectangleF srcRect = new RectangleF(0.0F, 0.0F, gridWidth, gridHeight);
            RectangleF destRect = new RectangleF(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);

            int maximum = this.value.Max();

            Font drawFont = new Font("Microsoft Sans Serif", 2, FontStyle.Bold, GraphicsUnit.Point, 0);

            Pen pen = new Pen(this.AxisColor, 0.5f);

            GraphicsContainer containerState = e.Graphics.BeginContainer(destRect, srcRect, GraphicsUnit.Pixel);

            for (int i = 0; i < this.value.Count; i++)
            {
                float barSize = 0.0f;

                if (this.value[i] > 0)
                {
                    barSize = this.value[i] * 100 / maximum;
                }

                e.Graphics.DrawString(i.ToString(), drawFont, brushFont, 0, i * 4 + 1 - 0.4f);

                e.Graphics.FillRectangle(brushBar, 5, i * 4 + 1, 1 + barSize, 2);

                e.Graphics.DrawString(this.value[i].ToString(), drawFont, brushFont, 6 + barSize + 0.5f, i * 4 + 1 - 0.4f);
            }

            e.Graphics.DrawLine(pen, 5, 0.5f, 5, this.gridHeight);
            e.Graphics.DrawLine(pen, 5, 0.5f, this.gridWidth - 5, 0.5f);

            e.Graphics.EndContainer(containerState);
        }
        #endregion
    }
}
