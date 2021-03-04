using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class DisplayOperationList : UserControl
    {
        private int currentControl = 0;

        private int nbOperationDisplayed = 15;

        private IEnumerable<Core.Statistics.Operation> data;

        public int NbOperationDisplayed
        {
            get
            {
                return this.nbOperationDisplayed;
            }
            set
            {
                this.nbOperationDisplayed = value;

                if (this.nbOperationDisplayed > this.tableOperationViews.Controls.Count)
                {
                    int nbNewRow = this.nbOperationDisplayed - this.tableOperationViews.Controls.Count;
                    for (int i = 0; i < nbNewRow; i++)
                    {
                        this.tableOperationViews.Controls.Add(new OperationView()
                        {
                            Visible = false,
                            Dock = DockStyle.Fill
                        });
                    }
                }
                else if (this.nbOperationDisplayed < this.tableOperationViews.Controls.Count)
                {
                    while (this.tableOperationViews.Controls.Count - this.nbOperationDisplayed > 0)
                    {
                        var item = this.tableOperationViews.Controls[this.tableOperationViews.Controls.Count - 1];
                        this.tableOperationViews.Controls.Remove(item);
                        item.Dispose();
                    }
                }

                if (this.data != null)
                {
                    this.SetValue(this.data.ToList());
                }
            }
        }

        public bool HighlightOperationOfYourFirehouse { get; set; } = false;

        public string FirehouseName { get; set; } = null;

        public Color BackgroundColorItem { get; set; } = Color.White;

        public Color FontColorItem { get; set; } = Color.Blue;

        public Color BackgroundColorHighlightItem { get; set; } = Color.Red;

        public Color FontColorHighLightItem { get; set; } = Color.Green;

        public string Title
        {
            get => this.title.Text;
            set => this.title.Text = value;
        }

        public DisplayOperationList()
        {
            InitializeComponent();

            this.timerAutoScroll.Start();
        }

        #region Public
        public void ApplyTheme(Extra.Theme.ITheme theme)
        {
            this.BackColor = theme.OperationListView_BackgroundColorList();
            this.ForeColor = theme.Form_FontColor();

            this.tableLayoutPanel.BackColor = theme.OperationListView_BackgroundColor();
            this.panel.BackColor = theme.OperationListView_BackgroundColorList();
            this.tableOperationViews.BackColor = theme.OperationListView_BackgroundColorList();

            this.title.ForeColor = theme.Form_FontColor();

            foreach (Control item in this.tableOperationViews.Controls)
            {

                item.BackColor = theme.OperationListView_BackgroundColorItem();
                item.ForeColor = theme.OperationListView_FontColorItem();
            }
        }

        public void SetValue(List<Core.Statistics.Operation> operations)
        {
            this.timerAutoScroll.Stop();

            this.data = operations;

            var settings = MainForm.Instance == null || MainForm.Instance.Settings == null ? new Core.Syst.Setting() : MainForm.Instance.Settings;

            int i;
            for (i = 0; i < this.NbOperationDisplayed && i < operations.Count(); i++)
            {
                ((OperationView)this.tableOperationViews.Controls[i]).Operation = operations[i];

                if (this.HighlightOperationOfYourFirehouse && !string.IsNullOrWhiteSpace(this.FirehouseName))
                {
                    if (operations[i].VehiculeEnrolled.Where(c => c.Contains(this.FirehouseName)).Count() > 0)
                    {
                        this.tableOperationViews.Controls[i].BackColor = settings.Theme.OperationListView_BackgroundColorHighlightItem();
                        this.tableOperationViews.Controls[i].ForeColor = settings.Theme.OperationListView_FontColorHighlightItem();
                    }
                    else
                    {
                        this.tableOperationViews.Controls[i].BackColor = settings.Theme.OperationListView_BackgroundColorItem();
                        this.tableOperationViews.Controls[i].ForeColor = settings.Theme.OperationListView_FontColorItem();
                    }
                }

                this.tableOperationViews.Controls[i].Visible = true;
            }

            for (; i < this.NbOperationDisplayed; i++)
            {
                this.tableOperationViews.Controls[i].Visible = false;
            }

            this.timerAutoScroll.Start();
        }
        #endregion

        #region Event
        private void TimerAutoScroll_Tick(object sender, EventArgs e)
        {
            this.timerAutoScroll.Stop();

            if (this.tableOperationViews.Controls.Count > 0)
            {
                if (this.currentControl < this.tableOperationViews.Controls.Count - 1)
                {
                    this.currentControl++;
                }
                else
                {
                    this.currentControl = 0;
                }

                this.panel.ScrollControlIntoView(this.tableOperationViews.Controls[this.currentControl]);
            }

            this.timerAutoScroll.Start();
        }
        #endregion
    }
}
