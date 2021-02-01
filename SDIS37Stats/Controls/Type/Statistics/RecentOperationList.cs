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
                var displayOperation = new DisplayOperation(operations[i])
                {
                    Dock = DockStyle.Fill,
                    BackColor = Theme.RecentOperationList.BackgroundColorItem
                };

                this.tableOperationDisplayed.Controls.Add(displayOperation);
                this.tableOperationDisplayed.SetColumn(displayOperation, 0);
                this.tableOperationDisplayed.SetRow(displayOperation, count);
                count++;
            }

            this.currentControl = 0;

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
