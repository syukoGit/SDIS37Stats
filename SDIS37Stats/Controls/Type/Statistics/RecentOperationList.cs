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

        public RecentOperationList()
        {
            InitializeComponent();
        }

        public void SetValue(List<Core.Statistics.Operation> operations)
        {
            displayOperations.Clear();
            this.tableLayoutPanel.Controls.Clear();

            this.tableLayoutPanel.RowCount = operations.Count;

            int count = 0;
            foreach (var item in operations)
            {
                var displayOperation = new DisplayOperation(item)
                { 
                    Dock = DockStyle.Fill
                };

                this.tableLayoutPanel.Controls.Add(displayOperation);
                this.tableLayoutPanel.SetColumn(displayOperation, 0);
                this.tableLayoutPanel.SetRow(displayOperation, count);
                count++;
            }
        }
    }
}
