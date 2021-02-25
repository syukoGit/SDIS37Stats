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
            this.LastUpdate = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NbOperationToday = new SDIS37Stats.Controls.Type.Statistics.NbOperationToday();
            this.NbOperationPerHour = new SDIS37Stats.Controls.Type.Statistics.NbOperationPerHour();
            this.RecentOperationList = new SDIS37Stats.Controls.Type.Statistics.DisplayOperationList();
            this.RecentOperationOfUserFirehouse = new SDIS37Stats.Controls.Type.Statistics.DisplayOperationList();
            this.displayFirefighterAvailabilityList = new SDIS37Stats.Controls.Type.Statistics.DisplayFirefighterAvailabilityList();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsPicture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // LastUpdate
            // 
            this.LastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LastUpdate.AutoSize = true;
            this.LastUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LastUpdate.Location = new System.Drawing.Point(249, 0);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.NbOperationToday, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NbOperationPerHour, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.RecentOperationList, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.RecentOperationOfUserFirehouse, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.displayFirefighterAvailabilityList, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1250, 658);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // NbOperationToday
            // 
            this.NbOperationToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NbOperationToday.Location = new System.Drawing.Point(3, 3);
            this.NbOperationToday.Name = "NbOperationToday";
            this.NbOperationToday.Size = new System.Drawing.Size(299, 111);
            this.NbOperationToday.TabIndex = 3;
            this.NbOperationToday.Value = 0;
            // 
            // NbOperationPerHour
            // 
            this.NbOperationPerHour.AutoSize = true;
            this.NbOperationPerHour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NbOperationPerHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NbOperationPerHour.Location = new System.Drawing.Point(3, 140);
            this.NbOperationPerHour.Name = "NbOperationPerHour";
            this.NbOperationPerHour.Size = new System.Drawing.Size(410, 254);
            this.NbOperationPerHour.TabIndex = 4;
            this.NbOperationPerHour.Value = ((System.Collections.Generic.List<int>)(resources.GetObject("NbOperationPerHour.Value")));
            // 
            // RecentOperationList
            // 
            this.RecentOperationList.AutoSize = true;
            this.RecentOperationList.BackgroundColorHighlightItem = System.Drawing.Color.Red;
            this.RecentOperationList.BackgroundColorItem = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.RecentOperationList, 2);
            this.RecentOperationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecentOperationList.FirehouseName = "RID";
            this.RecentOperationList.FontColorHighLightItem = System.Drawing.Color.Green;
            this.RecentOperationList.FontColorItem = System.Drawing.Color.Blue;
            this.RecentOperationList.HighlightOperationOfYourFirehouse = true;
            this.RecentOperationList.Location = new System.Drawing.Point(419, 140);
            this.RecentOperationList.Name = "RecentOperationList";
            this.RecentOperationList.NbOperationDisplayed = 15;
            this.RecentOperationList.Size = new System.Drawing.Size(828, 254);
            this.RecentOperationList.TabIndex = 5;
            this.RecentOperationList.Title = "Liste des dernières interventions :";
            // 
            // RecentOperationOfUserFirehouse
            // 
            this.RecentOperationOfUserFirehouse.AutoSize = true;
            this.RecentOperationOfUserFirehouse.BackgroundColorHighlightItem = System.Drawing.Color.Red;
            this.RecentOperationOfUserFirehouse.BackgroundColorItem = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.RecentOperationOfUserFirehouse, 2);
            this.RecentOperationOfUserFirehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecentOperationOfUserFirehouse.FirehouseName = null;
            this.RecentOperationOfUserFirehouse.FontColorHighLightItem = System.Drawing.Color.Green;
            this.RecentOperationOfUserFirehouse.FontColorItem = System.Drawing.Color.Blue;
            this.RecentOperationOfUserFirehouse.HighlightOperationOfYourFirehouse = false;
            this.RecentOperationOfUserFirehouse.Location = new System.Drawing.Point(419, 400);
            this.RecentOperationOfUserFirehouse.Name = "RecentOperationOfUserFirehouse";
            this.RecentOperationOfUserFirehouse.NbOperationDisplayed = 5;
            this.RecentOperationOfUserFirehouse.Size = new System.Drawing.Size(828, 255);
            this.RecentOperationOfUserFirehouse.TabIndex = 6;
            this.RecentOperationOfUserFirehouse.Title = "Liste des dernières interventions de ... :";
            // 
            // displayFirefighterAvailabilityList
            // 
            this.displayFirefighterAvailabilityList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayFirefighterAvailabilityList.Location = new System.Drawing.Point(3, 400);
            this.displayFirefighterAvailabilityList.Name = "displayFirefighterAvailabilityList";
            this.displayFirefighterAvailabilityList.NbAvailibilitiesDisplayed = 50;
            this.displayFirefighterAvailabilityList.Size = new System.Drawing.Size(410, 255);
            this.displayFirefighterAvailabilityList.TabIndex = 7;
            this.displayFirefighterAvailabilityList.Title = "Liste des disponibilités de ... :";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.LastUpdate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SettingsPicture, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(832, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(418, 117);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // SettingsPicture
            // 
            this.SettingsPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsPicture.Location = new System.Drawing.Point(380, 30);
            this.SettingsPicture.Name = "SettingsPicture";
            this.SettingsPicture.Size = new System.Drawing.Size(35, 35);
            this.SettingsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingsPicture.TabIndex = 3;
            this.SettingsPicture.TabStop = false;
            this.SettingsPicture.Click += new System.EventHandler(this.SettingsPicture_Click);
            this.SettingsPicture.MouseEnter += new System.EventHandler(this.SettingsPicture_MouseEnter);
            this.SettingsPicture.MouseLeave += new System.EventHandler(this.SettingsPicture_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1250, 658);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "MainForm";
            this.Text = "SDIS37 - Statistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LastUpdate;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Type.Statistics.NbOperationToday NbOperationToday;
        private Type.Statistics.NbOperationPerHour NbOperationPerHour;
        private Type.Statistics.DisplayOperationList RecentOperationList;
        private Type.Statistics.DisplayOperationList RecentOperationOfUserFirehouse;
        private Type.Statistics.DisplayFirefighterAvailabilityList displayFirefighterAvailabilityList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox SettingsPicture;
    }
}

