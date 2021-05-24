//-----------------------------------------------------------------------
// <copyright file="SevenSegmentArray.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.SevenSegment
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Class for make a <see cref="SevenSegment"/> array for display number.
    /// </summary>
    public class SevenSegmentArray : UserControl
    {
        /// <summary>
        /// All <see cref="SevenSegment"/> contained in this <see cref="SevenSegmentArray"/>.
        /// </summary>
        private SevenSegment[] segments = null;

        /// <summary>
        /// The width of the LED segments.
        /// </summary>
        private int elementWidth = 10;

        /// <summary>
        /// The shear coefficient for italicizing the displays. Try a value like -0.1.
        /// </summary>
        private float italicFactor = 0.0F;

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
        /// A value indicating whether the dot should be displayed.
        /// </summary>
        private bool showDot = true;

        /// <summary>
        /// Padding that applies to each seven-segment element in the array.
        /// </summary>
        private Padding elementPadding;

        /// <summary>
        /// The value to be displayed.
        /// </summary>
        private int theValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="SevenSegmentArray"/> class.
        /// </summary>
        public SevenSegmentArray()
        {
            this.SuspendLayout();
            this.Name = "SevenSegmentArray";
            this.Size = new Size(100, 25);
            this.Resize += new EventHandler(this.SevenSegmentArray_Resize);
            this.ResumeLayout(false);

            this.TabStop = false;
            this.elementPadding = new Padding(4, 4, 4, 4);
            this.RecreateSegments(4);
        }

        /// <summary>
        /// Gets or sets the background's color of the LED array.
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
                this.UpdateSegments();
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
                this.UpdateSegments();
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
                this.UpdateSegments();
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
                this.UpdateSegments();
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
                this.UpdateSegments();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the decimal point LED is displayed.
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
                this.UpdateSegments();
            }
        }

        /// <summary>
        /// Gets or sets the number of seven-segment elements in this array.
        /// </summary>
        public int ArrayCount
        {
            get
            {
                return this.segments.Length;
            }

            set
            {
                if ((value > 0) && (value <= 100))
                {
                    this.RecreateSegments(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the padding that applies to each seven-segment element in the array.
        /// Tweak these numbers to get the perfect appearance for the array of your size.
        /// </summary>
        public Padding ElementPadding
        {
            get
            {
                return this.elementPadding;
            }

            set
            {
                this.elementPadding = value;
                this.UpdateSegments();
            }
        }

        /// <summary>
        /// Gets or sets the value to be displayed on the LED array.
        /// </summary>
        public int Value
        {
            get
            {
                return this.theValue;
            }

            set
            {
                this.theValue = value;
                for (int i = 0; i < this.segments.Length; i++)
                {
                    this.segments[i].CustomPattern = 0;
                    this.segments[i].DecimalOn = false;
                }

                int segmentIndex = 0;
                for (int i = this.theValue.ToString().Length - 1; i >= 0; i--)
                {
                    if (segmentIndex >= this.segments.Length)
                    {
                        break;
                    }

                    if (this.theValue.ToString()[i] == '.')
                    {
                        this.segments[segmentIndex].DecimalOn = true;
                    }
                    else
                    {
                        this.segments[segmentIndex++].Value = int.Parse(this.theValue.ToString()[i].ToString());
                    }
                }
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
        /// Change the number of elements in our LED array. This destroys
        /// the previous elements, and creates new ones in their place, applying
        /// all the current options to the new ones.
        /// </summary>
        /// <param name="count">Number of elements to create.</param>
        private void RecreateSegments(int count)
        {
            if (this.segments != null)
            {
                foreach (SevenSegment sevenSegment in this.segments)
                {
                    sevenSegment.Parent = null;
                    sevenSegment.Dispose();
                }
            }

            if (count <= 0)
            {
                return;
            }

            this.segments = new SevenSegment[count];

            for (int i = 0; i < count; i++)
            {
                this.segments[i] = new ()
                {
                    Parent = this,
                    Top = 0,
                    Height = this.Height,
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                    Visible = true,
                };
            }

            this.ResizeSegments();
            this.UpdateSegments();
            this.Value = this.theValue;
        }

        /// <summary>
        /// Align the elements of the array to fit neatly within the
        /// width of the parent control.
        /// </summary>
        private void ResizeSegments()
        {
            int segWidth = this.Width / this.segments.Length;
            for (int i = 0; i < this.segments.Length; i++)
            {
                this.segments[i].Left = this.Width * (this.segments.Length - 1 - i) / this.segments.Length;
                this.segments[i].Width = segWidth;
            }
        }

        /// <summary>
        /// Update the properties of each element with the properties
        /// we have stored.
        /// </summary>
        private void UpdateSegments()
        {
            for (int i = 0; i < this.segments.Length; i++)
            {
                this.segments[i].ColorBackground = this.colorBackground;
                this.segments[i].ColorDark = this.colorDark;
                this.segments[i].ColorLight = this.colorLight;
                this.segments[i].ElementWidth = this.elementWidth;
                this.segments[i].ItalicFactor = this.italicFactor;
                this.segments[i].DecimalShow = this.showDot;
                this.segments[i].Padding = this.elementPadding;
            }
        }

        /// <summary>
        /// Called when the control should be resized.
        /// </summary>
        /// <param name="sender">A control which must be resized.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void SevenSegmentArray_Resize(object sender, EventArgs e)
        {
            this.ResizeSegments();
        }
    }
}
