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

                if (this.nbAvailibilitiesDisplayed > this.tableLayoutFirefighterAvailabilityView.Controls.Count)
                {
                    int nbNewRow = this.nbAvailibilitiesDisplayed - this.tableLayoutFirefighterAvailabilityView.Controls.Count;
                    for (int i = 0; i < nbNewRow; i++)
                    {
                        this.tableLayoutFirefighterAvailabilityView.Controls.Add(new FirefighterAvailabilityView()
                        {
                            Visible = false,
                            Dock = DockStyle.Fill
                        });
                    }
                }
                else if (this.nbAvailibilitiesDisplayed < this.tableLayoutFirefighterAvailabilityView.Controls.Count)
                {
                    while (this.tableLayoutFirefighterAvailabilityView.Controls.Count - this.nbAvailibilitiesDisplayed > 0)
                    {
                        var item = this.tableLayoutFirefighterAvailabilityView.Controls[this.tableLayoutFirefighterAvailabilityView.Controls.Count - 1];
                        this.tableLayoutFirefighterAvailabilityView.Controls.Remove(item);
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
            this.tableLayoutFirefighterAvailabilityView.BackColor = theme.FirefighterAvailabilityListView_BackgroundList();

            foreach (Control item in this.tableLayoutFirefighterAvailabilityView.Controls)
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
                ((FirefighterAvailabilityView)this.tableLayoutFirefighterAvailabilityView.Controls[i]).FirefighterAvailability = firefighters[i];
                this.tableLayoutFirefighterAvailabilityView.Controls[i].Visible = true;
            }

            for (; i < this.NbAvailibilitiesDisplayed; i++)
            {
                this.tableLayoutFirefighterAvailabilityView.Controls[i].Visible = false;
            }

            this.currentControl = 0;

            this.timerAutoScroll.Start();
        }
        #endregion

        #region Event
        private void TimerAutoScroll_Tick(object sender, EventArgs e)
        {
            this.timerAutoScroll.Stop();

            int nbObjectDisplayed = this.tableLayoutFirefighterAvailabilityView.Controls.Cast<Control>().Where(c => c.Visible == true).Count();

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

                this.panel.ScrollControlIntoView(this.tableLayoutFirefighterAvailabilityView.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
        #endregion
    }
}
