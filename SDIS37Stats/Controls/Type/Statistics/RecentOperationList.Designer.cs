namespace SDIS37Stats.Controls.Type.Statistics
{
    partial class RecentOperationList
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
            this.tableOperationDisplayed = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.title = new System.Windows.Forms.Label();
            this.timerAutoScroll = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableOperationDisplayed
            // 
            this.tableOperationDisplayed.AutoScroll = true;
            this.tableOperationDisplayed.ColumnCount = 1;
            this.tableOperationDisplayed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableOperationDisplayed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableOperationDisplayed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOperationDisplayed.Location = new System.Drawing.Point(0, 23);
            this.tableOperationDisplayed.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tableOperationDisplayed.Name = "tableOperationDisplayed";
            this.tableOperationDisplayed.RowCount = 2;
            this.tableOperationDisplayed.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableOperationDisplayed.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableOperationDisplayed.Size = new System.Drawing.Size(495, 77);
            this.tableOperationDisplayed.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.tableOperationDisplayed, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.title, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(495, 100);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(226, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(43, 20);
            this.title.TabIndex = 1;
            this.title.Text = "Title";
            // 
            // timerAutoScroll
            // 
            this.timerAutoScroll.Interval = 1000;
            this.timerAutoScroll.Tick += new System.EventHandler(this.TimerAutoScroll_Tick);
            // 
            // RecentOperationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "RecentOperationList";
            this.Size = new System.Drawing.Size(495, 100);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableOperationDisplayed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Timer timerAutoScroll;
    }
}
