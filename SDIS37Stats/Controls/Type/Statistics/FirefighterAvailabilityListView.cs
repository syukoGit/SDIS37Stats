using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class FirefighterAvailabilityListView : UserControl
    {
        private int currentControl = 0;

        private int nbAvailibilitiesDisplayed = 50;

        private readonly List<Core.Statistics.FirefighterAvailability> data = new();

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

                this.SetFirefighterAvailabilityViews();
            }
        }

        public FirefighterAvailabilityListView()
        {
            this.InitializeComponent();

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
            this.tableFirefighterAvailabilityViews.BackColor = theme.FirefighterAvailabilityListView_BackgroundList();

            foreach (Control item in this.tableFirefighterAvailabilityViews.Controls)
            {
                item.BackColor = theme.FirefighterAvailabilityListView_BackgroundColorItem();
                item.ForeColor = theme.Form_FontColor();
            }
        }

        public void SetFirefighterAvailabilities(IEnumerable<Core.Statistics.FirefighterAvailability> firefighterAvailabilities)
        {
            this.data.Clear();
            this.data.AddRange(firefighterAvailabilities);

            this.SetFirefighterAvailabilityViews();
        }
        #endregion

        #region Private
        private void SetFirefighterAvailabilityViews()
        {
            this.timerAutoScroll.Stop();

            this.tableFirefighterAvailabilityViews.SuspendLayout();

            if (this.tableFirefighterAvailabilityViews.Controls.Count > this.NbAvailibilitiesDisplayed)
            {
                for (int i = this.tableFirefighterAvailabilityViews.Controls.Count - 1; i >= this.NbAvailibilitiesDisplayed || i >= this.data.Count(); i--)
                {
                    var firefighterAvailabilityView = this.tableFirefighterAvailabilityViews.Controls[i];
                    this.tableFirefighterAvailabilityViews.Controls.Remove(firefighterAvailabilityView);
                    firefighterAvailabilityView?.Dispose();
                }
            }
            else
            {
                for (int i = this.tableFirefighterAvailabilityViews.Controls.Count; i < this.NbAvailibilitiesDisplayed && i < this.data.Count(); i++)
                {
                    this.tableFirefighterAvailabilityViews.Controls.Add(new FirefighterAvailabilityView()
                    {
                        Dock = DockStyle.Fill
                    });
                }
            }

            if (this.data != null && this.data.Any())
            {
                this.data.Sort((a, b) => a.CompareTo(b));

                System.Collections.IList controlList = this.tableFirefighterAvailabilityViews.Controls;
                for (int i = 0; i < controlList.Count; i++)
                {
                    var firefighterAvailabilityView = controlList[i] as FirefighterAvailabilityView;

                    if (firefighterAvailabilityView.FirefighterAvailability != this.data[i])
                    {
                        firefighterAvailabilityView.FirefighterAvailability = this.data[i];
                    }
                }
            }

            this.ApplyTheme(Core.Syst.Setting.CurrentSetting.Theme);

            this.tableFirefighterAvailabilityViews.ResumeLayout();

            if (this.tableFirefighterAvailabilityViews.Controls.Count > 0)
            {
                this.currentControl = 0;
                this.panel.ScrollControlIntoView(this.tableFirefighterAvailabilityViews.Controls[0]);
            }

            this.timerAutoScroll.Start();
        }
        #endregion

        #region Event
        private void TimerAutoScroll_Tick(object sender, EventArgs e)
        {
            this.timerAutoScroll.Stop();

            int nbObjectDisplayed = this.tableFirefighterAvailabilityViews.Controls.Cast<Control>().Where(c => c.Visible == true).Count();

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

                this.panel.ScrollControlIntoView(this.tableFirefighterAvailabilityViews.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
        #endregion
    }
}
