using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SDIS37Stats.Controls.Type.Statistics
{
    public partial class OperationListView : UserControl
    {
        private int currentControl = 0;

        private int nbOperationDisplayed = 15;

        private readonly List<Core.Statistics.Operation> data = new List<Core.Statistics.Operation>();

        public int NbOperationDisplayed
        {
            get
            {
                return this.nbOperationDisplayed;
            }
            set
            {
                this.nbOperationDisplayed = value;

                this.SetOperationViews();
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

        public OperationListView()
        {
            this.InitializeComponent();

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

        public void AddOperations(IEnumerable<Core.Statistics.Operation> operations)
        {
            this.data.AddRange(operations.Where(c => !this.data.Select(t => t.NumOperation).Contains(c.NumOperation)));

            this.SetOperationViews();
        }

        public void AddOperation(Core.Statistics.Operation operation)
        {
            if (this.data.Any(c => c.NumOperation == operation.NumOperation))
            {
                this.data.Add(operation);
            }

            this.SetOperationViews();
        }
        #endregion

        #region Private
        private void SetOperationViews()
        {
            this.timerAutoScroll.Stop();

            if (this.tableOperationViews.Controls.Count > this.nbOperationDisplayed)
            {
                for (int i = this.tableOperationViews.Controls.Count - 1; i >= this.nbOperationDisplayed || i >= this.data.Count(); i--)
                {
                    var operationView = this.tableOperationViews.Controls[i];
                    this.tableOperationViews.Controls.Remove(operationView);
                    operationView?.Dispose();
                }
            }
            else
            {
                for (int i = this.tableOperationViews.Controls.Count; i < this.nbOperationDisplayed && i < this.data.Count(); i++)
                {
                    this.tableOperationViews.Controls.Add(new OperationView()
                    {
                        Dock = DockStyle.Fill
                    });
                }
            }

            if (this.data != null && this.data.Any())
            {
                this.data.Sort((a, b) => b.Time.CompareTo(a.Time));

                System.Collections.IList controlList = this.tableOperationViews.Controls;
                for (int i = 0; i < controlList.Count; i++)
                {
                    OperationView operationView = (OperationView)controlList[i];

                    var settings = MainForm.Instance == null || MainForm.Instance.Settings == null ? new Core.Syst.Setting() : MainForm.Instance.Settings;

                    if (operationView.Operation != this.data[i])
                    {
                        operationView.Operation = this.data[i];

                        if (this.HighlightOperationOfYourFirehouse && !string.IsNullOrWhiteSpace(this.FirehouseName))
                        {
                            if (operationView.Operation.VehiculeEnrolled.Any(c => c.Contains(this.FirehouseName)))
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
                    }
                }
            }

            if (this.tableOperationViews.Controls.Count > 0)
            {
                this.currentControl = 0;
                this.panel.ScrollControlIntoView(this.tableOperationViews.Controls[0]);
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
