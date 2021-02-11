
namespace SDIS37Stats.Controls.Type.Statistics
{
    partial class DisplayFirefighterAvailabilityList
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
            this.tableLayoutDisplayFirefighterAvailability = new System.Windows.Forms.TableLayoutPanel();
            this.timerAutoScroll = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Controls.Add(this.title, 0, 0);
            this.tableLayoutMain.Controls.Add(this.tableLayoutDisplayFirefighterAvailability, 0, 1);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Size = new System.Drawing.Size(382, 118);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(169, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(43, 20);
            this.title.TabIndex = 0;
            this.title.Text = "Title";
            // 
            // tableLayoutDisplayFirefighterAvailability
            // 
            this.tableLayoutDisplayFirefighterAvailability.AutoScroll = true;
            this.tableLayoutDisplayFirefighterAvailability.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutDisplayFirefighterAvailability.ColumnCount = 1;
            this.tableLayoutDisplayFirefighterAvailability.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutDisplayFirefighterAvailability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutDisplayFirefighterAvailability.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutDisplayFirefighterAvailability.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tableLayoutDisplayFirefighterAvailability.Name = "tableLayoutDisplayFirefighterAvailability";
            this.tableLayoutDisplayFirefighterAvailability.RowCount = 1;
            this.tableLayoutDisplayFirefighterAvailability.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutDisplayFirefighterAvailability.Size = new System.Drawing.Size(382, 95);
            this.tableLayoutDisplayFirefighterAvailability.TabIndex = 1;
            // 
            // timerAutoScroll
            // 
            this.timerAutoScroll.Interval = 1000;
            this.timerAutoScroll.Tick += new System.EventHandler(this.TimerAutoScroll_Tick);
            // 
            // DisplayFirefighterAvailabilityList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "DisplayFirefighterAvailabilityList";
            this.Size = new System.Drawing.Size(382, 118);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutDisplayFirefighterAvailability;
        private System.Windows.Forms.Timer timerAutoScroll;
    }
}
