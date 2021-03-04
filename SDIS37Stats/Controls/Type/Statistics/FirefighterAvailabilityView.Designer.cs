
namespace SDIS37Stats.Controls.Type.Statistics
{
    partial class FirefighterAvailabilityView
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
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutRankAndName = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelRank = new System.Windows.Forms.Label();
            this.pictureBoxAvailability = new System.Windows.Forms.PictureBox();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutRankAndName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvailability)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.AutoSize = true;
            this.tableLayoutMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutMain.Controls.Add(this.tableLayoutRankAndName, 1, 0);
            this.tableLayoutMain.Controls.Add(this.pictureBoxAvailability, 0, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(177, 30);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // tableLayoutRankAndName
            // 
            this.tableLayoutRankAndName.AutoSize = true;
            this.tableLayoutRankAndName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutRankAndName.ColumnCount = 2;
            this.tableLayoutRankAndName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutRankAndName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutRankAndName.Controls.Add(this.labelName, 1, 0);
            this.tableLayoutRankAndName.Controls.Add(this.labelRank, 0, 0);
            this.tableLayoutRankAndName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutRankAndName.Location = new System.Drawing.Point(61, 0);
            this.tableLayoutRankAndName.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutRankAndName.Name = "tableLayoutRankAndName";
            this.tableLayoutRankAndName.RowCount = 1;
            this.tableLayoutRankAndName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutRankAndName.Size = new System.Drawing.Size(116, 30);
            this.tableLayoutRankAndName.TabIndex = 2;
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(40, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(72, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Antonin Lyaët";
            // 
            // labelRank
            // 
            this.labelRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRank.AutoSize = true;
            this.labelRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRank.Location = new System.Drawing.Point(3, 8);
            this.labelRank.Name = "labelRank";
            this.labelRank.Size = new System.Drawing.Size(31, 13);
            this.labelRank.TabIndex = 1;
            this.labelRank.Text = "SAP";
            // 
            // pictureBoxAvailability
            // 
            this.pictureBoxAvailability.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxAvailability.Location = new System.Drawing.Point(36, 7);
            this.pictureBoxAvailability.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pictureBoxAvailability.Name = "pictureBoxAvailability";
            this.pictureBoxAvailability.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxAvailability.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxAvailability.TabIndex = 3;
            this.pictureBoxAvailability.TabStop = false;
            // 
            // DisplayFirefighterAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(10, 30);
            this.Name = "DisplayFirefighterAvailability";
            this.Size = new System.Drawing.Size(177, 30);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.tableLayoutRankAndName.ResumeLayout(false);
            this.tableLayoutRankAndName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvailability)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutRankAndName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelRank;
        private System.Windows.Forms.PictureBox pictureBoxAvailability;
    }
}
