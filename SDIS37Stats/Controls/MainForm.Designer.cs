﻿namespace SDIS37Stats.Controls
{
    partial class MainForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.LastUpdate = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NbOperationToday = new SDIS37Stats.Controls.Type.Statistics.NbOperationToday();
            this.NbOperationPerHour = new SDIS37Stats.Controls.Type.Statistics.NbOperationPerHour();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // LastUpdate
            // 
            this.LastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LastUpdate.AutoSize = true;
            this.LastUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LastUpdate.Location = new System.Drawing.Point(1006, 0);
            this.LastUpdate.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LastUpdate.Size = new System.Drawing.Size(169, 27);
            this.LastUpdate.TabIndex = 2;
            this.LastUpdate.Text = "24/01/2021 06:00";
            this.LastUpdate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer
            // 
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.LastUpdate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.NbOperationToday, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NbOperationPerHour, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1175, 591);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // NbOperationToday
            // 
            this.NbOperationToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NbOperationToday.Location = new System.Drawing.Point(3, 3);
            this.NbOperationToday.Name = "NbOperationToday";
            this.NbOperationToday.Size = new System.Drawing.Size(299, 111);
            this.NbOperationToday.TabIndex = 3;
            this.NbOperationToday.Value = 126;
            // 
            // NbOperationPerHour
            // 
            this.NbOperationPerHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NbOperationPerHour.Location = new System.Drawing.Point(3, 140);
            this.NbOperationPerHour.Name = "NbOperationPerHour";
            this.NbOperationPerHour.Size = new System.Drawing.Size(581, 428);
            this.NbOperationPerHour.TabIndex = 4;
            this.NbOperationPerHour.Value = ((System.Collections.Generic.List<int>)(resources.GetObject("NbOperationPerHour.Value")));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1175, 591);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "MainForm";
            this.Text = "SDIS37 - Statistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LastUpdate;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Type.Statistics.NbOperationToday NbOperationToday;
        private Type.Statistics.NbOperationPerHour NbOperationPerHour;
    }
}

