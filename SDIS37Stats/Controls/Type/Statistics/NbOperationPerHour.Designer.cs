namespace SDIS37Stats.Controls.Type.Statistics
{
    partial class NbOperationPerHour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NbOperationPerHour));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fix_label = new System.Windows.Forms.Label();
            this.barGraph = new SDIS37Stats.Controls.Type.Graph.BarGraph();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.fix_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.barGraph, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 215);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fix_label
            // 
            this.fix_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fix_label.AutoSize = true;
            this.fix_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fix_label.Location = new System.Drawing.Point(21, 0);
            this.fix_label.Name = "fix_label";
            this.fix_label.Size = new System.Drawing.Size(285, 20);
            this.fix_label.TabIndex = 0;
            this.fix_label.Text = "Nombre d\'interventions par heure :";
            this.fix_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barGraph
            // 
            this.barGraph.AutoSize = true;
            this.barGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barGraph.Location = new System.Drawing.Point(0, 23);
            this.barGraph.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.barGraph.Name = "barGraph";
            this.barGraph.Size = new System.Drawing.Size(327, 192);
            this.barGraph.TabIndex = 1;
            this.barGraph.TabStop = false;
            this.barGraph.Value = ((System.Collections.Generic.List<int>)(resources.GetObject("barGraph.Value")));
            // 
            // NbOperationPerHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NbOperationPerHour";
            this.Size = new System.Drawing.Size(327, 215);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label fix_label;
        private Graph.BarGraph barGraph;
    }
}
