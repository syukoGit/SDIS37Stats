using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class DisplayFirefighterAvailabilityList : UserControl
    {
        private int currentControl = 0;

        private int nbAvailibilitiesDisplayed = 50;

        private IEnumerable<Core.Statistics.FirefighterAvailability> data;

        public string Title
        {
            get => this.title.Text;
            set => this.title.Text = value;
        }

        public int NbAvailibilitiesDisplayed
        {
            get
            {
                return this.nbAvailibilitiesDisplayed;
            }
            set
            {
                this.nbAvailibilitiesDisplayed = value;

                if (this.nbAvailibilitiesDisplayed > this.tableLayoutDisplayFirefighterAvailability.Controls.Count)
                {
                    int nbNewRow = this.nbAvailibilitiesDisplayed - this.tableLayoutDisplayFirefighterAvailability.Controls.Count;
                    for (int i = 0; i < nbNewRow; i++)
                    {
                        this.tableLayoutDisplayFirefighterAvailability.Controls.Add(new DisplayFirefighterAvailability()
                        {
                            Visible = false,
                            Dock = DockStyle.Fill
                        });
                    }
                }
                else if (this.nbAvailibilitiesDisplayed < this.tableLayoutDisplayFirefighterAvailability.Controls.Count)
                {
                    while (this.tableLayoutDisplayFirefighterAvailability.Controls.Count - this.nbAvailibilitiesDisplayed > 0)
                    {
                        var item = this.tableLayoutDisplayFirefighterAvailability.Controls[this.tableLayoutDisplayFirefighterAvailability.Controls.Count - 1];
                        this.tableLayoutDisplayFirefighterAvailability.Controls.Remove(item);
                        item.Dispose();
                    }
                }

                if (this.data != null)
                {
                    this.SetValue(this.data.ToList());
                }
            }
        }

        public DisplayFirefighterAvailabilityList()
        {
            InitializeComponent();

            this.timerAutoScroll.Start();
        }

        #region Public
        public void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.Form_BackgroundColor();
            this.ForeColor = theme.Form_FontColor();

            this.tableLayoutMain.BackColor = theme.FirefighterAvailabilityListView_BackgroundColor();

            this.title.ForeColor = theme.Form_FontColor();

            this.panel.BackColor = theme.FirefighterAvailabilityListView_BackgroundList();
            this.tableLayoutDisplayFirefighterAvailability.BackColor = theme.FirefighterAvailabilityListView_BackgroundList();

            foreach (Control item in this.tableLayoutDisplayFirefighterAvailability.Controls)
            {
                item.BackColor = theme.FirefighterAvailabilityListView_BackgroundColorItem();
                item.ForeColor = theme.Form_FontColor();
            }
        }

        public void SetValue(List<Core.Statistics.FirefighterAvailability> firefighters)
        {
            this.timerAutoScroll.Stop();

            this.data = firefighters;

            int i;
            for (i = 0; i < this.NbAvailibilitiesDisplayed && i < firefighters.Count; i++)
            {
                ((DisplayFirefighterAvailability)this.tableLayoutDisplayFirefighterAvailability.Controls[i]).FirefighterAvailability = firefighters[i];
                this.tableLayoutDisplayFirefighterAvailability.Controls[i].Visible = true;
            }

            for (; i < this.NbAvailibilitiesDisplayed; i++)
            {
                this.tableLayoutDisplayFirefighterAvailability.Controls[i].Visible = false;
            }

            this.currentControl = 0;

            this.timerAutoScroll.Start();
        }
        #endregion

        #region Event
        private void TimerAutoScroll_Tick(object sender, EventArgs e)
        {
            this.timerAutoScroll.Stop();

            int nbObjectDisplayed = this.tableLayoutDisplayFirefighterAvailability.Controls.Cast<Control>().Where(c => c.Visible == true).Count();

            if (nbObjectDisplayed > 0)
            {
                if (this.currentControl < nbObjectDisplayed - 1)
                {
                    this.currentControl++;
                }
                else
                {
                    this.currentControl = 0;
                }

                this.panel.ScrollControlIntoView(this.tableLayoutDisplayFirefighterAvailability.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
        #endregion
    }
}
