namespace SDIS37Stats.Controls.Type.Statistics
{
    partial class DisplayOperation
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.time = new System.Windows.Forms.Label();
            this.numOperation = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.localisation = new System.Windows.Forms.Label();
            this.OperationDescription = new System.Windows.Forms.Label();
            this.vehicules = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.time, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numOperation, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.vehicules, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // time
            // 
            this.time.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(4, 28);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(95, 13);
            this.time.TabIndex = 0;
            this.time.Text = "25/01/2021 05:47";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numOperation
            // 
            this.numOperation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numOperation.AutoSize = true;
            this.numOperation.Location = new System.Drawing.Point(106, 28);
            this.numOperation.Name = "numOperation";
            this.numOperation.Size = new System.Drawing.Size(55, 13);
            this.numOperation.TabIndex = 1;
            this.numOperation.Text = "21002087";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.localisation, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.OperationDescription, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(168, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(260, 62);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // localisation
            // 
            this.localisation.AutoSize = true;
            this.localisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localisation.Location = new System.Drawing.Point(3, 0);
            this.localisation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.localisation.Name = "localisation";
            this.localisation.Size = new System.Drawing.Size(254, 26);
            this.localisation.TabIndex = 0;
            this.localisation.Text = "AZAY-LE-RIDEAU";
            this.localisation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // OperationDescription
            // 
            this.OperationDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationDescription.Location = new System.Drawing.Point(3, 36);
            this.OperationDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.OperationDescription.Name = "OperationDescription";
            this.OperationDescription.Size = new System.Drawing.Size(254, 26);
            this.OperationDescription.TabIndex = 1;
            this.OperationDescription.Text = "DOMICILE : PERSONNE RESTANT A TERRE SUITE A CHUTE CHUTE MECA / TRAUMA HANCHE";
            // 
            // vehicules
            // 
            this.vehicules.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.vehicules.AutoSize = true;
            this.vehicules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vehicules.Location = new System.Drawing.Point(435, 22);
            this.vehicules.Name = "vehicules";
            this.vehicules.Size = new System.Drawing.Size(57, 26);
            this.vehicules.TabIndex = 3;
            this.vehicules.Text = "VSAV RID\r\nFPT RID\r\n";
            // 
            // DisplayOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.MinimumSize = new System.Drawing.Size(500, 70);
            this.Name = "DisplayOperation";
            this.Size = new System.Drawing.Size(500, 70);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label numOperation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label localisation;
        private System.Windows.Forms.Label OperationDescription;
        private System.Windows.Forms.Label vehicules;
    }
}
