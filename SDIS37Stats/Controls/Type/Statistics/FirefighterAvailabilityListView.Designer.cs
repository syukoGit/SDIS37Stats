
namespace SDIS37Stats.Controls.Type.Statistics
{
    partial class FirefighterAvailabilityListView
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.title = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.tableFirefighterAvailabilityViews = new System.Windows.Forms.TableLayoutPanel();
            this.timerAutoScroll = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutMain.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Controls.Add(this.title, 0, 0);
            this.tableLayoutMain.Controls.Add(this.panel, 0, 1);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Size = new System.Drawing.Size(446, 136);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(223, 0);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(0, 20);
            this.title.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.tableFirefighterAvailabilityViews);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 23);
            this.panel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(446, 113);
            this.panel.TabIndex = 1;
            // 
            // tableFirefighterAvailabilityViews
            // 
            this.tableFirefighterAvailabilityViews.AutoSize = true;
            this.tableFirefighterAvailabilityViews.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableFirefighterAvailabilityViews.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableFirefighterAvailabilityViews.ColumnCount = 1;
            this.tableFirefighterAvailabilityViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableFirefighterAvailabilityViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableFirefighterAvailabilityViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableFirefighterAvailabilityViews.Location = new System.Drawing.Point(0, 0);
            this.tableFirefighterAvailabilityViews.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableFirefighterAvailabilityViews.Name = "tableFirefighterAvailabilityViews";
            this.tableFirefighterAvailabilityViews.RowCount = 1;
            this.tableFirefighterAvailabilityViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableFirefighterAvailabilityViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableFirefighterAvailabilityViews.Size = new System.Drawing.Size(446, 2);
            this.tableFirefighterAvailabilityViews.TabIndex = 0;
            // 
            // timerAutoScroll
            // 
            this.timerAutoScroll.Interval = 1000;
            this.timerAutoScroll.Tick += new System.EventHandler(this.TimerAutoScroll_Tick);
            // 
            // FirefighterAvailabilityListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FirefighterAvailabilityListView";
            this.Size = new System.Drawing.Size(446, 136);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Timer timerAutoScroll;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TableLayoutPanel tableFirefighterAvailabilityViews;
    }
}
