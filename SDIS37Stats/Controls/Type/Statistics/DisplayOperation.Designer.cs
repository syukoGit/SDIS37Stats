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
            this.pictureBoxOperationType = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOperationType)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.time, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numOperation, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.vehicules, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxOperationType, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 64);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // time
            // 
            this.time.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(4, 25);
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
            this.numOperation.Location = new System.Drawing.Point(128, 25);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(190, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(248, 56);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // localisation
            // 
            this.localisation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.localisation.AutoSize = true;
            this.localisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localisation.Location = new System.Drawing.Point(3, 10);
            this.localisation.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.localisation.Name = "localisation";
            this.localisation.Size = new System.Drawing.Size(109, 13);
            this.localisation.TabIndex = 0;
            this.localisation.Text = "AZAY-LE-RIDEAU";
            this.localisation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // OperationDescription
            // 
            this.OperationDescription.AutoSize = true;
            this.OperationDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationDescription.Location = new System.Drawing.Point(3, 33);
            this.OperationDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.OperationDescription.Name = "OperationDescription";
            this.OperationDescription.Size = new System.Drawing.Size(242, 13);
            this.OperationDescription.TabIndex = 1;
            this.OperationDescription.Text = "DOMICILE : PERSONNE RESTANT A TERRE";
            // 
            // vehicules
            // 
            this.vehicules.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.vehicules.AutoSize = true;
            this.vehicules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vehicules.Location = new System.Drawing.Point(445, 25);
            this.vehicules.Name = "vehicules";
            this.vehicules.Size = new System.Drawing.Size(57, 13);
            this.vehicules.TabIndex = 3;
            this.vehicules.Text = "VSAV RID";
            this.vehicules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxOperationType
            // 
            this.pictureBoxOperationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxOperationType.Location = new System.Drawing.Point(106, 24);
            this.pictureBoxOperationType.Name = "pictureBoxOperationType";
            this.pictureBoxOperationType.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxOperationType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxOperationType.TabIndex = 4;
            this.pictureBoxOperationType.TabStop = false;
            // 
            // DisplayOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.Name = "DisplayOperation";
            this.Size = new System.Drawing.Size(507, 64);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOperationType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label numOperation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label localisation;
        private System.Windows.Forms.Label OperationDescription;
        private System.Windows.Forms.Label vehicules;
        private System.Windows.Forms.PictureBox pictureBoxOperationType;
    }
}
