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
    public partial class RecentOperationList : UserControl
    {
        private readonly List<DisplayOperation> displayOperations = new List<DisplayOperation>();

        private int currentControl = 0;

        public int NbOperationDisplayed { get; set; } = 6;

        public bool HighlightOperationOfYourFirehouse { get; set; } = false;

        public string FirehouseName { get; set; } = null;

        public string Title
        {
            get => this.title.Text;
            set => this.title.Text = value;
        }

        public RecentOperationList()
        {
            InitializeComponent();

            this.tableOperationDisplayed.BackColor = Theme.RecentOperationList.BackgroundList;

            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            this.tableOperationDisplayed.Padding = new Padding(0, 0, vertScrollWidth - 15, 0);

            this.timerAutoScroll.Start();
        }

        public void SetValue(List<Core.Statistics.Operation> operations)
        {
            this.timerAutoScroll.Stop();

            displayOperations.Clear();
            this.tableOperationDisplayed.Controls.Clear();

            this.tableOperationDisplayed.RowCount = operations.Count;

            int count = 0;
            for (int i = 0; i < this.NbOperationDisplayed && i < operations.Count; i++)
            {
                Color backgroundColor = Theme.RecentOperationList.BackgroundColorItem;
                Color fontColor = Theme.RecentOperationList.FontColorItem;

                if (this.HighlightOperationOfYourFirehouse && !string.IsNullOrWhiteSpace(this.FirehouseName))
                {
                    if (operations[i].VehiculeEnrolled.Where(c => c.Contains(this.FirehouseName)).Count() > 0)
                    {
                        backgroundColor = Theme.RecentOperationList.BackgroundColorHighlightItem;
                        fontColor = Theme.RecentOperationList.FontColorHighlightItem;
                    }
                }

                var displayOperation = new DisplayOperation(operations[i])
                {
                    Dock = DockStyle.Fill,
                    BackColor = backgroundColor,
                    ForeColor = fontColor
                };

                this.tableOperationDisplayed.Controls.Add(displayOperation);
                this.tableOperationDisplayed.SetColumn(displayOperation, 0);
                this.tableOperationDisplayed.SetRow(displayOperation, count);
                count++;
            }

            this.currentControl = 0;
            if (this.tableOperationDisplayed.Controls.Count > 0)
            {
                this.tableOperationDisplayed.ScrollControlIntoView(this.tableOperationDisplayed.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }

        #region Event
        private void TimerAutoScroll_Tick(object sender, EventArgs e)
        {
            this.timerAutoScroll.Stop();

            if (this.tableOperationDisplayed.Controls.Count > 0)
            {
                if (this.currentControl < this.tableOperationDisplayed.Controls.Count - 1)
                {
                    this.currentControl++;
                }
                else
                {
                    this.currentControl = 0;
                }

                this.tableOperationDisplayed.ScrollControlIntoView(this.tableOperationDisplayed.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
        #endregion
    }
}
