using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class DisplayFirefighterAvailabilityList : UserControl
    {
        private int currentControl = 0;

        public string Title
        {
            get => this.title.Text;
            set => this.title.Text = value;
        }

        public int NbAvailibilitiesDisplayed { get; set; } = 100;

        public DisplayFirefighterAvailabilityList()
        {
            InitializeComponent();

            this.tableLayoutDisplayFirefighterAvailability.BackColor = Theme.DisplayOperationList.BackgroundList;

            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            this.tableLayoutDisplayFirefighterAvailability.Padding = new Padding(0, 0, vertScrollWidth - 16, 0);

            this.timerAutoScroll.Start();
        }

        #region Public
        public void SetValue(List<Core.Statistics.FirefighterAvailability> firefighters)
        {
            this.timerAutoScroll.Stop();

            this.tableLayoutDisplayFirefighterAvailability.Controls.Clear();

            this.tableLayoutDisplayFirefighterAvailability.RowCount = firefighters.Count + 1;

            int count = 0;
            for (int i = 0; i < this.NbAvailibilitiesDisplayed && i < firefighters.Count; i++)
            {
                var displayFirefighterAvailability = new DisplayFirefighterAvailability(firefighters[i])
                {
                    Dock = DockStyle.Fill,
                    BackColor = Theme.DisplayFirefighterAvailabilityList.BackgroundColorItem,
                    ForeColor = Theme.DisplayFirefighterAvailabilityList.FontColorItem
                };

                this.tableLayoutDisplayFirefighterAvailability.Controls.Add(displayFirefighterAvailability);
                this.tableLayoutDisplayFirefighterAvailability.SetColumn(displayFirefighterAvailability, 0);
                this.tableLayoutDisplayFirefighterAvailability.SetRow(displayFirefighterAvailability, count);
                count++;
            }

            this.currentControl = 0;
            if (this.tableLayoutDisplayFirefighterAvailability.Controls.Count > 0)
            {
                this.tableLayoutDisplayFirefighterAvailability.ScrollControlIntoView(this.tableLayoutDisplayFirefighterAvailability.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
        #endregion

        #region Event
        private void TimerAutoScroll_Tick(object sender, EventArgs e)
        {
            this.timerAutoScroll.Stop();

            if (this.tableLayoutDisplayFirefighterAvailability.Controls.Count > 0)
            {
                if (this.currentControl < this.tableLayoutDisplayFirefighterAvailability.Controls.Count - 1)
                {
                    this.currentControl++;
                }
                else
                {
                    this.currentControl = 0;
                }

                this.tableLayoutDisplayFirefighterAvailability.ScrollControlIntoView(this.tableLayoutDisplayFirefighterAvailability.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
        #endregion
    }
}
