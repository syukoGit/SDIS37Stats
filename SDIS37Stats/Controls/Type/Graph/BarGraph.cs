//-----------------------------------------------------------------------
// <copyright file="BarGraph.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SDIS37Stats.Controls.Type.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Class for make a <see cref="BarGraph"/> with bars at the horizontal.
    /// </summary>
    public partial class BarGraph : UserControl
    {
        /// <summary>
        /// Grid's width used to draw the graph.
        /// </summary>
        private readonly int gridWidth = 116;

        /// <summary>
        /// Grid's height used to draw the graph.
        /// </summary>
        private int gridHeight = 96;

        /// <summary>
        /// Value list displayed by the graph.
        /// </summary>
        private List<int> value = new () { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Initializes a new instance of the <see cref="BarGraph" /> class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the value list displayed by the graph.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the background's color of the graphic.
        /// </summary>
        public Color BackGroundGraphColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the axis color.
        /// </summary>
        public Color AxisColor { get; set; } = Color.Yellow;

        /// <summary>
        /// Gets or sets the main bars' color.
        /// </summary>
        public Color MainBarColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets the values' color.
        /// </summary>
        public Color ValueColor { get; set; } = Color.Red;

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackGroundGraphColor);
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
        /// Called when the control should be resized.
        /// </summary>
        /// <param name="sender">A object which must be resized.</param>
        /// <param name="e"> A <see cref="EventArgs"/> that contains the event data.</param>
        private void Graph_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Called when the control should be painted.
        /// </summary>
        /// <param name="sender">A object which must be painted.</param>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains information about the control to paint.</param>
        private void Graph_Paint(object sender, PaintEventArgs e)
        {
            Brush brushBar = new SolidBrush(this.MainBarColor);
            Brush brushFont = new SolidBrush(this.ValueColor);

            int maximum = this.value.Max();

            GraphicsContainer containerState = e.Graphics.BeginContainer(new RectangleF(this.Padding.Left, this.Padding.Top, this.Width - this.Padding.Left - this.Padding.Right, this.Height - this.Padding.Top - this.Padding.Bottom), new RectangleF(0.0F, 0.0F, this.gridWidth, this.gridHeight), GraphicsUnit.Pixel);

            for (int i = 0; i < this.value.Count; i++)
            {
                float barSize = 0.0f;

                if (this.value[i] > 0)
                {
                    barSize = this.value[i] * 100 / maximum;
                }

                e.Graphics.DrawString(i.ToString(), new Font("Microsoft Sans Serif", 2, FontStyle.Bold, GraphicsUnit.Point, 0), brushFont, 0, (i * 4) + 1 - 0.4f);

                e.Graphics.FillRectangle(brushBar, 5, (i * 4) + 1, 1 + barSize, 2);

                e.Graphics.DrawString(this.value[i].ToString(), new Font("Microsoft Sans Serif", 2, FontStyle.Bold, GraphicsUnit.Point, 0), brushFont, 6 + barSize + 0.5f, (i * 4) + 1 - 0.4f);
            }

            e.Graphics.DrawLine(new Pen(this.AxisColor, 0.5f), 5, 0.5f, 5, this.gridHeight);
            e.Graphics.DrawLine(new Pen(this.AxisColor, 0.5f), 5, 0.5f, this.gridWidth - 5, 0.5f);

            e.Graphics.EndContainer(containerState);
        }
    }
}
