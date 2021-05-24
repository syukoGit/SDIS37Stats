//-----------------------------------------------------------------------
// <copyright file="SevenSegment.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.SevenSegment
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    /// <summary>
    /// Class for make a <see cref="SevenSegment"/>.
    /// </summary>
    public class SevenSegment : UserControl
    {
        /// <summary>
        /// A two-dimensional <see cref="Point"/> table that contains the points for painting the segments.
        /// </summary>
        private readonly Point[][] segPoints;

        /// <summary>
        /// Grid's height used to draw the graph.
        /// </summary>
        private readonly int gridHeight = 80;

        /// <summary>
        /// Grid's width used to draw the graph.
        /// </summary>
        private readonly int gridWidth = 48;

        /// <summary>
        /// The width of LED segments.
        /// </summary>
        private int elementWidth = 10;

        /// <summary>
        /// The shear coefficient for italicizing the displays.
        /// </summary>
        private float italicFactor = 0.0f;

        /// <summary>
        /// The color of the segments' background.
        /// </summary>
        private Color colorBackground = Color.DarkGray;

        /// <summary>
        /// The color of inactive LED segments.
        /// </summary>
        private Color colorDark = Color.DimGray;

        /// <summary>
        /// The color of active LED segments.
        /// </summary>
        private Color colorLight = Color.Red;

        /// <summary>
        /// The value to be displayed.
        /// </summary>
        private int theValue;

        /// <summary>
        /// A value indicating whether the dot should be displayed.
        /// </summary>
        private bool showDot = true;

        /// <summary>
        /// A value indicating whether the dot is activated.
        /// </summary>
        private bool dotOn = false;

        /// <summary>
        /// A value indicating whether the colon should be displayed.
        /// </summary>
        private bool showColon = false;

        /// <summary>
        /// A value indicating whether the colon is activated.
        /// </summary>
        private bool colonOn = false;

        /// <summary>
        /// The custom pattern which is used to drive the segments.
        /// </summary>
        private int customPattern = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="SevenSegment"/> class.
        /// </summary>
        public SevenSegment()
        {
            this.SuspendLayout();
            this.Name = "SevenSegment";
            this.Size = new Size(32, 64);
            this.Paint += this.SevenSegment_Paint;
            this.Resize += this.SevenSegment_Resize;
            this.ResumeLayout(false);

            this.TabStop = false;
            this.Padding = new Padding(4, 4, 4, 4);
            this.DoubleBuffered = true;

            this.segPoints = new Point[7][];
            for (int i = 0; i < 7; i++)
            {
                this.segPoints[i] = new Point[6];
            }

            this.RecalculatePoints();
        }

        /// <summary>
        /// Enumeration for define the value pattern.
        /// </summary>
        public enum EValuePattern
        {
            /// <summary>
            /// Value for not painting anything.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Value for painting a zero.
            /// </summary>
            Zero = 0x77,

            /// <summary>
            /// Value for painting a one.
            /// </summary>
            One = 0x24,

            /// <summary>
            /// Value for painting a two.
            /// </summary>
            Two = 0x5D,

            /// <summary>
            /// Value for painting a three.
            /// </summary>
            Three = 0x6D,

            /// <summary>
            /// Value for painting a four.
            /// </summary>
            Four = 0x2E,

            /// <summary>
            /// Value for painting a five.
            /// </summary>
            Five = 0x6B,

            /// <summary>
            /// Value for painting a six.
            /// </summary>
            Six = 0x7B,

            /// <summary>
            /// Value for painting a seven.
            /// </summary>
            Seven = 0x25,

            /// <summary>
            /// Value for painting a eight.
            /// </summary>
            Eight = 0x7F,

            /// <summary>
            /// Value for painting a nine.
            /// </summary>
            Nine = 0x6F,
        }

        /// <summary>
        /// Gets or sets the background's color.
        /// </summary>
        public Color ColorBackground
        {
            get
            {
                return this.colorBackground;
            }

            set
            {
                this.colorBackground = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of inactive LED segments.
        /// </summary>
        public Color ColorDark
        {
            get
            {
                return this.colorDark;
            }

            set
            {
                this.colorDark = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of active LED segments.
        /// </summary>
        public Color ColorLight
        {
            get
            {
                return this.colorLight;
            }

            set
            {
                this.colorLight = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of LED segments.
        /// </summary>
        public int ElementWidth
        {
            get
            {
                return this.elementWidth;
            }

            set
            {
                this.elementWidth = value;
                this.RecalculatePoints();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shear coefficient for italicizing the displays. Try a value like -0.1.
        /// </summary>
        public float ItalicFactor
        {
            get
            {
                return this.italicFactor;
            }

            set
            {
                this.italicFactor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public int Value
        {
            get
            {
                return this.theValue;
            }

            set
            {
                this.customPattern = 0;
                this.theValue = value;
                this.Invalidate();

                if (this.theValue > 9)
                {
                    this.theValue = 9;
                }

                if (this.theValue < 0)
                {
                    this.theValue = 0;
                }

                this.customPattern = this.theValue switch
                {
                    0 => (int)EValuePattern.Zero,
                    1 => (int)EValuePattern.One,
                    2 => (int)EValuePattern.Two,
                    3 => (int)EValuePattern.Three,
                    4 => (int)EValuePattern.Four,
                    5 => (int)EValuePattern.Five,
                    6 => (int)EValuePattern.Six,
                    7 => (int)EValuePattern.Seven,
                    8 => (int)EValuePattern.Eight,
                    9 => (int)EValuePattern.Nine,
                    _ => (int)EValuePattern.Zero
                };
            }
        }

        /// <summary>
        /// Gets or sets the custom pattern which is used to drive the segments.
        /// The value must be between 0 and 127.
        /// </summary>
        public int CustomPattern
        {
            get
            {
                return this.customPattern;
            }

            set
            {
                this.customPattern = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the dot should be displayed.
        /// </summary>
        public bool DecimalShow
        {
            get
            {
                return this.showDot;
            }

            set
            {
                this.showDot = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the dot is activated.
        /// </summary>
        public bool DecimalOn
        {
            get
            {
                return this.dotOn;
            }

            set
            {
                this.dotOn = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the colon should be displayed.
        /// </summary>
        public bool ColonShow
        {
            get
            {
                return this.showColon;
            }

            set
            {
                this.showColon = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the colon is activated.
        /// </summary>
        public bool ColonOn
        {
            get
            {
                return this.colonOn;
            }

            set
            {
                this.colonOn = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(this.colorBackground);
        }

        /// <summary>
        /// Raises the PaddingChanged event.
        /// </summary>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            this.Invalidate();
        }

        /// <summary>
        /// Recalculate the points for each segment.
        /// </summary>
        private void RecalculatePoints()
        {
            int halfHeight = this.gridHeight / 2, halfWidth = this.elementWidth / 2;

            // Segment 0 (upper segment)
            int p = 0;
            this.segPoints[p][0].X = this.elementWidth + 1;
            this.segPoints[p][0].Y = 0;
            this.segPoints[p][1].X = this.gridWidth - this.elementWidth - 1;
            this.segPoints[p][1].Y = 0;
            this.segPoints[p][2].X = this.gridWidth - halfWidth - 1;
            this.segPoints[p][2].Y = halfWidth;
            this.segPoints[p][3].X = this.gridWidth - this.elementWidth - 1;
            this.segPoints[p][3].Y = this.elementWidth;
            this.segPoints[p][4].X = this.elementWidth + 1;
            this.segPoints[p][4].Y = this.elementWidth;
            this.segPoints[p][5].X = halfWidth + 1;
            this.segPoints[p][5].Y = halfWidth;

            // Segment 1 (upper left segment)
            p++;
            this.segPoints[p][0].X = 0;
            this.segPoints[p][0].Y = this.elementWidth + 1;
            this.segPoints[p][1].X = halfWidth;
            this.segPoints[p][1].Y = halfWidth + 1;
            this.segPoints[p][2].X = this.elementWidth;
            this.segPoints[p][2].Y = this.elementWidth + 1;
            this.segPoints[p][3].X = this.elementWidth;
            this.segPoints[p][3].Y = halfHeight - halfWidth - 1;
            this.segPoints[p][4].X = 4;
            this.segPoints[p][4].Y = halfHeight - 1;
            this.segPoints[p][5].X = 0;
            this.segPoints[p][5].Y = halfHeight - 1;

            // Segment 2 (upper right segment)
            p++;
            this.segPoints[p][0].X = this.gridWidth - this.elementWidth;
            this.segPoints[p][0].Y = this.elementWidth + 1;
            this.segPoints[p][1].X = this.gridWidth - halfWidth;
            this.segPoints[p][1].Y = halfWidth + 1;
            this.segPoints[p][2].X = this.gridWidth;
            this.segPoints[p][2].Y = this.elementWidth + 1;
            this.segPoints[p][3].X = this.gridWidth;
            this.segPoints[p][3].Y = halfHeight - 1;
            this.segPoints[p][4].X = this.gridWidth - 4;
            this.segPoints[p][4].Y = halfHeight - 1;
            this.segPoints[p][5].X = this.gridWidth - this.elementWidth;
            this.segPoints[p][5].Y = halfHeight - halfWidth - 1;

            // Segment 3 (middle segment)
            p++;
            this.segPoints[p][0].X = this.elementWidth + 1;
            this.segPoints[p][0].Y = halfHeight - halfWidth;
            this.segPoints[p][1].X = this.gridWidth - this.elementWidth - 1;
            this.segPoints[p][1].Y = halfHeight - halfWidth;
            this.segPoints[p][2].X = this.gridWidth - 5;
            this.segPoints[p][2].Y = halfHeight;
            this.segPoints[p][3].X = this.gridWidth - this.elementWidth - 1;
            this.segPoints[p][3].Y = halfHeight + halfWidth;
            this.segPoints[p][4].X = this.elementWidth + 1;
            this.segPoints[p][4].Y = halfHeight + halfWidth;
            this.segPoints[p][5].X = 5;
            this.segPoints[p][5].Y = halfHeight;

            // Segment 4 (lower left segment)
            p++;
            this.segPoints[p][0].X = 0;
            this.segPoints[p][0].Y = halfHeight + 1;
            this.segPoints[p][1].X = 4;
            this.segPoints[p][1].Y = halfHeight + 1;
            this.segPoints[p][2].X = this.elementWidth;
            this.segPoints[p][2].Y = halfHeight + halfWidth + 1;
            this.segPoints[p][3].X = this.elementWidth;
            this.segPoints[p][3].Y = this.gridHeight - this.elementWidth - 1;
            this.segPoints[p][4].X = halfWidth;
            this.segPoints[p][4].Y = this.gridHeight - halfWidth - 1;
            this.segPoints[p][5].X = 0;
            this.segPoints[p][5].Y = this.gridHeight - this.elementWidth - 1;

            // Segment 5 (lower right segment)
            p++;
            this.segPoints[p][0].X = this.gridWidth - this.elementWidth;
            this.segPoints[p][0].Y = halfHeight + halfWidth + 1;
            this.segPoints[p][1].X = this.gridWidth - 4;
            this.segPoints[p][1].Y = halfHeight + 1;
            this.segPoints[p][2].X = this.gridWidth;
            this.segPoints[p][2].Y = halfHeight + 1;
            this.segPoints[p][3].X = this.gridWidth;
            this.segPoints[p][3].Y = this.gridHeight - this.elementWidth - 1;
            this.segPoints[p][4].X = this.gridWidth - halfWidth;
            this.segPoints[p][4].Y = this.gridHeight - halfWidth - 1;
            this.segPoints[p][5].X = this.gridWidth - this.elementWidth;
            this.segPoints[p][5].Y = this.gridHeight - this.elementWidth - 1;

            // Segment 6 (lower segment)
            p++;
            this.segPoints[p][0].X = this.elementWidth + 1;
            this.segPoints[p][0].Y = this.gridHeight - this.elementWidth;
            this.segPoints[p][1].X = this.gridWidth - this.elementWidth - 1;
            this.segPoints[p][1].Y = this.gridHeight - this.elementWidth;
            this.segPoints[p][2].X = this.gridWidth - halfWidth - 1;
            this.segPoints[p][2].Y = this.gridHeight - halfWidth;
            this.segPoints[p][3].X = this.gridWidth - this.elementWidth - 1;
            this.segPoints[p][3].Y = this.gridHeight;
            this.segPoints[p][4].X = this.elementWidth + 1;
            this.segPoints[p][4].Y = this.gridHeight;
            this.segPoints[p][5].X = halfWidth + 1;
            this.segPoints[p][5].Y = this.gridHeight - halfWidth;
        }

        /// <summary>
        /// Called when the control should be resized.
        /// </summary>
        /// <param name="sender">The control which must be resized.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void SevenSegment_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Called when the control should be painted.
        /// </summary>
        /// <param name="sender">A control which must be resized.</param>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains information about the control to paint.</param>
        private void SevenSegment_Paint(object sender, PaintEventArgs e)
        {
            int useValue = this.customPattern;

            Brush brushLight = new SolidBrush(this.colorLight);
            Brush brushDark = new SolidBrush(this.colorDark);

            // Define transformation for our container...
            RectangleF srcRect;

            int colonWidth = this.gridWidth / 4;

            srcRect = this.showColon ? new RectangleF(0.0F, 0.0F, this.gridWidth + colonWidth, this.gridHeight) : new RectangleF(0.0F, 0.0F, this.gridWidth, this.gridHeight);

            // Begin graphics container that remaps coordinates for our convenience
            GraphicsContainer containerState = e.Graphics.BeginContainer(new RectangleF(this.Padding.Left, this.Padding.Top, this.Width - this.Padding.Left - this.Padding.Right, this.Height - this.Padding.Top - this.Padding.Bottom), srcRect, GraphicsUnit.Pixel);

            Matrix trans = new ();
            trans.Shear(this.italicFactor, 0.0F);
            e.Graphics.Transform = trans;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;

            // Draw elements based on whether the corresponding bit is high
            e.Graphics.FillPolygon((useValue & 0x1) == 0x1 ? brushLight : brushDark, this.segPoints[0]);
            e.Graphics.FillPolygon((useValue & 0x2) == 0x2 ? brushLight : brushDark, this.segPoints[1]);
            e.Graphics.FillPolygon((useValue & 0x4) == 0x4 ? brushLight : brushDark, this.segPoints[2]);
            e.Graphics.FillPolygon((useValue & 0x8) == 0x8 ? brushLight : brushDark, this.segPoints[3]);
            e.Graphics.FillPolygon((useValue & 0x10) == 0x10 ? brushLight : brushDark, this.segPoints[4]);
            e.Graphics.FillPolygon((useValue & 0x20) == 0x20 ? brushLight : brushDark, this.segPoints[5]);
            e.Graphics.FillPolygon((useValue & 0x40) == 0x40 ? brushLight : brushDark, this.segPoints[6]);

            if (this.showDot)
            {
                e.Graphics.FillEllipse(this.dotOn ? brushLight : brushDark, this.gridWidth - 1, this.gridHeight - this.elementWidth + 1, this.elementWidth, this.elementWidth);
            }

            if (this.showColon)
            {
                e.Graphics.FillEllipse(this.colonOn ? brushLight : brushDark, this.gridWidth + colonWidth - 4, (this.gridHeight / 4) - this.elementWidth + 8, this.elementWidth, this.elementWidth);
                e.Graphics.FillEllipse(this.colonOn ? brushLight : brushDark, this.gridWidth + colonWidth - 4, (this.gridHeight * 3 / 4) - this.elementWidth + 4, this.elementWidth, this.elementWidth);
            }

            e.Graphics.EndContainer(containerState);
        }
    }
}
