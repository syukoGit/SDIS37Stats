using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SDIS37Stats.Controls.Type.SevenSegment
{
    public class SevenSegment : UserControl
    {
        private readonly Point[][] segPoints;

        private readonly int gridHeight = 80;
        private readonly int gridWidth = 48;
        private int elementWidth = 10;
        private float italicFactor = 0.0f;
        private Color colorBackground = Color.DarkGray;
        private Color colorDark = Color.DimGray;
        private Color colorLight = Color.Red;

        private int theValue;
        private bool showDot = true, dotOn = false;
        private bool showColon = false, colonOn = false;
        private int customPattern = 0;

        public enum ValuePattern
        {
            None = 0x0, Zero = 0x77, One = 0x24, Two = 0x5D, Three = 0x6D,
            Four = 0x2E, Five = 0x6B, Six = 0x7B, Seven = 0x25,
            Eight = 0x7F, Nine = 0x6F
        }

        public SevenSegment()
        {
            SuspendLayout();
            Name = "SevenSegment";
            Size = new Size(32, 64);
            Paint += new PaintEventHandler(SevenSegment_Paint);
            Resize += new EventHandler(SevenSegment_Resize);
            ResumeLayout(false);

            TabStop = false;
            Padding = new Padding(4, 4, 4, 4);
            DoubleBuffered = true;

            segPoints = new Point[7][];
            for (int i = 0; i < 7; i++)
                segPoints[i] = new Point[6];

            RecalculatePoints();
        }

        public Color ColorBackground
        {
            get
            {
                return colorBackground;
            }

            set
            {
                colorBackground = value;
                Invalidate();
            }
        }

        public Color ColorDark
        {
            get
            {
                return colorDark;
            }

            set
            {
                colorDark = value;
                Invalidate();
            }
        }

        public Color ColorLight
        {
            get
            {
                return colorLight;
            }
            
            set
            {
                colorLight = value;
                Invalidate();
            }
        }

        public int ElementWidth
        {
            get
            {
                return elementWidth;
            }
            
            set
            {
                elementWidth = value;
                RecalculatePoints();
                Invalidate();
            }
        }

        public float ItalicFactor
        {
            get
            {
                return italicFactor;
            }
            
            set
            {
                italicFactor = value;
                Invalidate();
            }
        }

        public int Value
        {
            get
            {
                return theValue;
            }
            set
            {
                customPattern = 0;
                theValue = value;
                Invalidate();

                if (theValue > 9)
                    theValue = 9;

                if (theValue < 0)
                    theValue = 0;

                switch (theValue)
                {
                    case 0: customPattern = (int)ValuePattern.Zero; break;
                    case 1: customPattern = (int)ValuePattern.One; break;
                    case 2: customPattern = (int)ValuePattern.Two; break;
                    case 3: customPattern = (int)ValuePattern.Three; break;
                    case 4: customPattern = (int)ValuePattern.Four; break;
                    case 5: customPattern = (int)ValuePattern.Five; break;
                    case 6: customPattern = (int)ValuePattern.Six; break;
                    case 7: customPattern = (int)ValuePattern.Seven; break;
                    case 8: customPattern = (int)ValuePattern.Eight; break;
                    case 9: customPattern = (int)ValuePattern.Nine; break;
                }
            }
        }

        public int CustomPattern
        {
            get
            {
                return customPattern;
            }
            
            set
            {
                customPattern = value;
                Invalidate();
            }
        }

        public bool DecimalShow
        {
            get
            {
                return showDot;
            }
            
            set
            {
                showDot = value;
                Invalidate();
            }
        }

        public bool DecimalOn
        {
            get
            {
                return dotOn;
            }
            
            set
            {
                dotOn = value;
                Invalidate();
            }
        }

        public bool ColonShow
        {
            get
            {
                return showColon;
            }
            
            set
            {
                showColon = value;
                Invalidate();
            }
        }

        public bool ColonOn
        {
            get
            {
                return colonOn;
            }
            
            set
            {
                colonOn = value;
                Invalidate();
            }
        }

        protected override void OnPaddingChanged(EventArgs e) { base.OnPaddingChanged(e); Invalidate(); }

        #region Private
        private void RecalculatePoints()
        {
            int halfHeight = gridHeight / 2, halfWidth = elementWidth / 2;

            int p = 0;
            segPoints[p][0].X = elementWidth + 1; segPoints[p][0].Y = 0;
            segPoints[p][1].X = gridWidth - elementWidth - 1; segPoints[p][1].Y = 0;
            segPoints[p][2].X = gridWidth - halfWidth - 1; segPoints[p][2].Y = halfWidth;
            segPoints[p][3].X = gridWidth - elementWidth - 1; segPoints[p][3].Y = elementWidth;
            segPoints[p][4].X = elementWidth + 1; segPoints[p][4].Y = elementWidth;
            segPoints[p][5].X = halfWidth + 1; segPoints[p][5].Y = halfWidth;

            p++;
            segPoints[p][0].X = 0; segPoints[p][0].Y = elementWidth + 1;
            segPoints[p][1].X = halfWidth; segPoints[p][1].Y = halfWidth + 1;
            segPoints[p][2].X = elementWidth; segPoints[p][2].Y = elementWidth + 1;
            segPoints[p][3].X = elementWidth; segPoints[p][3].Y = halfHeight - halfWidth - 1;
            segPoints[p][4].X = 4; segPoints[p][4].Y = halfHeight - 1;
            segPoints[p][5].X = 0; segPoints[p][5].Y = halfHeight - 1;

            p++;
            segPoints[p][0].X = gridWidth - elementWidth; segPoints[p][0].Y = elementWidth + 1;
            segPoints[p][1].X = gridWidth - halfWidth; segPoints[p][1].Y = halfWidth + 1;
            segPoints[p][2].X = gridWidth; segPoints[p][2].Y = elementWidth + 1;
            segPoints[p][3].X = gridWidth; segPoints[p][3].Y = halfHeight - 1;
            segPoints[p][4].X = gridWidth - 4; segPoints[p][4].Y = halfHeight - 1;
            segPoints[p][5].X = gridWidth - elementWidth; segPoints[p][5].Y = halfHeight - halfWidth - 1;

            p++;
            segPoints[p][0].X = elementWidth + 1; segPoints[p][0].Y = halfHeight - halfWidth;
            segPoints[p][1].X = gridWidth - elementWidth - 1; segPoints[p][1].Y = halfHeight - halfWidth;
            segPoints[p][2].X = gridWidth - 5; segPoints[p][2].Y = halfHeight;
            segPoints[p][3].X = gridWidth - elementWidth - 1; segPoints[p][3].Y = halfHeight + halfWidth;
            segPoints[p][4].X = elementWidth + 1; segPoints[p][4].Y = halfHeight + halfWidth;
            segPoints[p][5].X = 5; segPoints[p][5].Y = halfHeight;

            p++;
            segPoints[p][0].X = 0; segPoints[p][0].Y = halfHeight + 1;
            segPoints[p][1].X = 4; segPoints[p][1].Y = halfHeight + 1;
            segPoints[p][2].X = elementWidth; segPoints[p][2].Y = halfHeight + halfWidth + 1;
            segPoints[p][3].X = elementWidth; segPoints[p][3].Y = gridHeight - elementWidth - 1;
            segPoints[p][4].X = halfWidth; segPoints[p][4].Y = gridHeight - halfWidth - 1;
            segPoints[p][5].X = 0; segPoints[p][5].Y = gridHeight - elementWidth - 1;

            p++;
            segPoints[p][0].X = gridWidth - elementWidth; segPoints[p][0].Y = halfHeight + halfWidth + 1;
            segPoints[p][1].X = gridWidth - 4; segPoints[p][1].Y = halfHeight + 1;
            segPoints[p][2].X = gridWidth; segPoints[p][2].Y = halfHeight + 1;
            segPoints[p][3].X = gridWidth; segPoints[p][3].Y = gridHeight - elementWidth - 1;
            segPoints[p][4].X = gridWidth - halfWidth; segPoints[p][4].Y = gridHeight - halfWidth - 1;
            segPoints[p][5].X = gridWidth - elementWidth; segPoints[p][5].Y = gridHeight - elementWidth - 1;

            p++;
            segPoints[p][0].X = elementWidth + 1; segPoints[p][0].Y = gridHeight - elementWidth;
            segPoints[p][1].X = gridWidth - elementWidth - 1; segPoints[p][1].Y = gridHeight - elementWidth;
            segPoints[p][2].X = gridWidth - halfWidth - 1; segPoints[p][2].Y = gridHeight - halfWidth;
            segPoints[p][3].X = gridWidth - elementWidth - 1; segPoints[p][3].Y = gridHeight;
            segPoints[p][4].X = elementWidth + 1; segPoints[p][4].Y = gridHeight;
            segPoints[p][5].X = halfWidth + 1; segPoints[p][5].Y = gridHeight - halfWidth;
        }
        #endregion

        #region Event
        private void SevenSegment_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(colorBackground);
        }

        private void SevenSegment_Paint(object sender, PaintEventArgs e)
        {
            int useValue = customPattern;

            Brush brushLight = new SolidBrush(colorLight);
            Brush brushDark = new SolidBrush(colorDark);

            // Define transformation for our container...
            RectangleF srcRect;

            int colonWidth = gridWidth / 4;

            if (showColon)
            {
                srcRect = new RectangleF(0.0F, 0.0F, gridWidth + colonWidth, gridHeight);
            }
            else
            {
                srcRect = new RectangleF(0.0F, 0.0F, gridWidth, gridHeight);
            }
            RectangleF destRect = new(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);

            // Begin graphics container that remaps coordinates for our convenience
            GraphicsContainer containerState = e.Graphics.BeginContainer(destRect, srcRect, GraphicsUnit.Pixel);

            Matrix trans = new();
            trans.Shear(italicFactor, 0.0F);
            e.Graphics.Transform = trans;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;

            // Draw elements based on whether the corresponding bit is high
            e.Graphics.FillPolygon((useValue & 0x1) == 0x1 ? brushLight : brushDark, segPoints[0]);
            e.Graphics.FillPolygon((useValue & 0x2) == 0x2 ? brushLight : brushDark, segPoints[1]);
            e.Graphics.FillPolygon((useValue & 0x4) == 0x4 ? brushLight : brushDark, segPoints[2]);
            e.Graphics.FillPolygon((useValue & 0x8) == 0x8 ? brushLight : brushDark, segPoints[3]);
            e.Graphics.FillPolygon((useValue & 0x10) == 0x10 ? brushLight : brushDark, segPoints[4]);
            e.Graphics.FillPolygon((useValue & 0x20) == 0x20 ? brushLight : brushDark, segPoints[5]);
            e.Graphics.FillPolygon((useValue & 0x40) == 0x40 ? brushLight : brushDark, segPoints[6]);

            if (showDot)
                e.Graphics.FillEllipse(dotOn ? brushLight : brushDark, gridWidth - 1, gridHeight - elementWidth + 1, elementWidth, elementWidth);

            if (showColon)
            {
                e.Graphics.FillEllipse(colonOn ? brushLight : brushDark, gridWidth + colonWidth - 4, gridHeight / 4 - elementWidth + 8, elementWidth, elementWidth);
                e.Graphics.FillEllipse(colonOn ? brushLight : brushDark, gridWidth + colonWidth - 4, gridHeight * 3 / 4 - elementWidth + 4, elementWidth, elementWidth);
            }

            e.Graphics.EndContainer(containerState);
        }
        #endregion
    }
}
