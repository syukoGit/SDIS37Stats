namespace SDIS37Stats.Controls.Type.Statistics
{
    partial class NbOperationToday
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
            this.sevenSegmentArray1 = new SDIS37Stats.Controls.Type.SevenSegment.SevenSegmentArray();
            this.fix_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.sevenSegmentArray1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fix_label, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 127);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sevenSegmentArray1
            // 
            this.sevenSegmentArray1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sevenSegmentArray1.ArrayCount = 3;
            this.sevenSegmentArray1.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sevenSegmentArray1.ColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.sevenSegmentArray1.ColorLight = System.Drawing.SystemColors.ButtonFace;
            this.sevenSegmentArray1.DecimalShow = false;
            this.sevenSegmentArray1.ElementPadding = new System.Windows.Forms.Padding(4);
            this.sevenSegmentArray1.ElementWidth = 12;
            this.sevenSegmentArray1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.sevenSegmentArray1.ItalicFactor = 0F;
            this.sevenSegmentArray1.Location = new System.Drawing.Point(73, 26);
            this.sevenSegmentArray1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sevenSegmentArray1.Name = "sevenSegmentArray1";
            this.sevenSegmentArray1.Size = new System.Drawing.Size(203, 91);
            this.sevenSegmentArray1.TabIndex = 1;
            this.sevenSegmentArray1.TabStop = false;
            this.sevenSegmentArray1.Value = 126;
            // 
            // fix_label
            // 
            this.fix_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fix_label.AutoSize = true;
            this.fix_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fix_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fix_label.Location = new System.Drawing.Point(34, 3);
            this.fix_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fix_label.Name = "fix_label";
            this.fix_label.Size = new System.Drawing.Size(281, 20);
            this.fix_label.TabIndex = 0;
            this.fix_label.Text = "Nombre d\'intervention aujoud\'hui :";
            // 
            // NbOperationToday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "NbOperationToday";
            this.Size = new System.Drawing.Size(350, 127);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SevenSegment.SevenSegmentArray sevenSegmentArray1;
        private System.Windows.Forms.Label fix_label;
    }
}
