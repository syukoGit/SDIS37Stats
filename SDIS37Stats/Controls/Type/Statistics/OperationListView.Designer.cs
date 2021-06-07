namespace SDIS37Stats.Controls.Type.Statistics
{
    partial class OperationListView
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.title = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.tableOperationViews = new System.Windows.Forms.TableLayoutPanel();
            this.timerAutoScroll = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.title, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(578, 115);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(289, 0);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(0, 20);
            this.title.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.tableOperationViews);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 20);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(578, 95);
            this.panel.TabIndex = 2;
            // 
            // tableOperationViews
            // 
            this.tableOperationViews.AutoSize = true;
            this.tableOperationViews.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableOperationViews.ColumnCount = 1;
            this.tableOperationViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableOperationViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableOperationViews.Location = new System.Drawing.Point(0, 0);
            this.tableOperationViews.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableOperationViews.Name = "tableOperationViews";
            this.tableOperationViews.RowCount = 1;
            this.tableOperationViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableOperationViews.Size = new System.Drawing.Size(578, 0);
            this.tableOperationViews.TabIndex = 0;
            // 
            // timerAutoScroll
            // 
            this.timerAutoScroll.Interval = 1000;
            this.timerAutoScroll.Tick += new System.EventHandler(this.TimerAutoScroll_Tick);
            // 
            // OperationListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OperationListView";
            this.Size = new System.Drawing.Size(578, 115);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Timer timerAutoScroll;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TableLayoutPanel tableOperationViews;
    }
}
