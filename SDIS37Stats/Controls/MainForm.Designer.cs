namespace SDIS37Stats.Controls
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
            this.LastUpdate = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nbOperationToday = new SDIS37Stats.Controls.Type.Statistics.NbOperationToday();
            this.nbOperationPerHour = new SDIS37Stats.Controls.Type.Statistics.NbOperationPerHour();
            this.recentOperationList = new SDIS37Stats.Controls.Type.Statistics.OperationListView();
            this.recentOperationOfUserFirehouse = new SDIS37Stats.Controls.Type.Statistics.OperationListView();
            this.firefighterAvailabilityListView = new SDIS37Stats.Controls.Type.Statistics.FirefighterAvailabilityListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsPicture = new System.Windows.Forms.PictureBox();
            this.webServiceState = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webServiceState)).BeginInit();
            this.SuspendLayout();
            // 
            // LastUpdate
            // 
            this.LastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LastUpdate.AutoSize = true;
            this.LastUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LastUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LastUpdate.Location = new System.Drawing.Point(317, 0);
            this.LastUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
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
            this.tableLayoutPanel1.Controls.Add(this.nbOperationToday, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nbOperationPerHour, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.recentOperationList, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.recentOperationOfUserFirehouse, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.firefighterAvailabilityListView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1458, 759);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // nbOperationToday
            // 
            this.nbOperationToday.Location = new System.Drawing.Point(5, 3);
            this.nbOperationToday.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nbOperationToday.Name = "nbOperationToday";
            this.nbOperationToday.Size = new System.Drawing.Size(349, 128);
            this.nbOperationToday.Statistics = null;
            this.nbOperationToday.TabIndex = 3;
            // 
            // nbOperationPerHour
            // 
            this.nbOperationPerHour.AutoSize = true;
            this.nbOperationPerHour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nbOperationPerHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nbOperationPerHour.Location = new System.Drawing.Point(5, 161);
            this.nbOperationPerHour.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nbOperationPerHour.Name = "nbOperationPerHour";
            this.nbOperationPerHour.Size = new System.Drawing.Size(476, 294);
            this.nbOperationPerHour.Statistics = null;
            this.nbOperationPerHour.TabIndex = 4;
            // 
            // recentOperationList
            // 
            this.recentOperationList.AutoSize = true;
            this.recentOperationList.BackgroundColorHighlightItem = System.Drawing.Color.Red;
            this.recentOperationList.BackgroundColorItem = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.recentOperationList, 2);
            this.recentOperationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentOperationList.FirehouseName = "RID";
            this.recentOperationList.FontColorHighLightItem = System.Drawing.Color.Green;
            this.recentOperationList.FontColorItem = System.Drawing.Color.Blue;
            this.recentOperationList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.recentOperationList.HighlightOperationOfUserFirehouse = true;
            this.recentOperationList.Location = new System.Drawing.Point(491, 161);
            this.recentOperationList.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.recentOperationList.Name = "recentOperationList";
            this.recentOperationList.OnlyOperationOfUserFirehouse = false;
            this.recentOperationList.Size = new System.Drawing.Size(962, 294);
            this.recentOperationList.Statistics = null;
            this.recentOperationList.TabIndex = 5;
            // 
            // recentOperationOfUserFirehouse
            // 
            this.recentOperationOfUserFirehouse.AutoSize = true;
            this.recentOperationOfUserFirehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.recentOperationOfUserFirehouse.BackgroundColorHighlightItem = System.Drawing.Color.Red;
            this.recentOperationOfUserFirehouse.BackgroundColorItem = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.recentOperationOfUserFirehouse, 2);
            this.recentOperationOfUserFirehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentOperationOfUserFirehouse.FirehouseName = null;
            this.recentOperationOfUserFirehouse.FontColorHighLightItem = System.Drawing.Color.Green;
            this.recentOperationOfUserFirehouse.FontColorItem = System.Drawing.Color.Blue;
            this.recentOperationOfUserFirehouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.recentOperationOfUserFirehouse.HighlightOperationOfUserFirehouse = false;
            this.recentOperationOfUserFirehouse.Location = new System.Drawing.Point(491, 461);
            this.recentOperationOfUserFirehouse.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.recentOperationOfUserFirehouse.Name = "recentOperationOfUserFirehouse";
            this.recentOperationOfUserFirehouse.OnlyOperationOfUserFirehouse = false;
            this.recentOperationOfUserFirehouse.Size = new System.Drawing.Size(962, 295);
            this.recentOperationOfUserFirehouse.Statistics = null;
            this.recentOperationOfUserFirehouse.TabIndex = 6;
            // 
            // firefighterAvailabilityListView
            // 
            this.firefighterAvailabilityListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.firefighterAvailabilityListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firefighterAvailabilityListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.firefighterAvailabilityListView.Location = new System.Drawing.Point(5, 461);
            this.firefighterAvailabilityListView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.firefighterAvailabilityListView.Name = "firefighterAvailabilityListView";
            this.firefighterAvailabilityListView.Size = new System.Drawing.Size(476, 295);
            this.firefighterAvailabilityListView.Statistics = null;
            this.firefighterAvailabilityListView.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.LastUpdate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(972, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(486, 135);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.SettingsPicture, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.webServiceState, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(486, 108);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // SettingsPicture
            // 
            this.SettingsPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsPicture.Location = new System.Drawing.Point(441, 3);
            this.SettingsPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SettingsPicture.Name = "SettingsPicture";
            this.SettingsPicture.Size = new System.Drawing.Size(41, 40);
            this.SettingsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingsPicture.TabIndex = 3;
            this.SettingsPicture.TabStop = false;
            this.SettingsPicture.Click += new System.EventHandler(this.SettingsPicture_Click);
            this.SettingsPicture.MouseEnter += new System.EventHandler(this.SettingsPicture_MouseEnter);
            this.SettingsPicture.MouseLeave += new System.EventHandler(this.SettingsPicture_MouseLeave);
            // 
            // webServiceState
            // 
            this.webServiceState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webServiceState.Location = new System.Drawing.Point(389, 3);
            this.webServiceState.Name = "webServiceState";
            this.webServiceState.Size = new System.Drawing.Size(45, 45);
            this.webServiceState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.webServiceState.TabIndex = 4;
            this.webServiceState.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1458, 759);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "SDIS37 - Statistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webServiceState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LastUpdate;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Type.Statistics.NbOperationToday nbOperationToday;
        private Type.Statistics.NbOperationPerHour nbOperationPerHour;
        private Type.Statistics.OperationListView recentOperationList;
        private Type.Statistics.OperationListView recentOperationOfUserFirehouse;
        private Type.Statistics.FirefighterAvailabilityListView firefighterAvailabilityListView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox SettingsPicture;
        private System.Windows.Forms.PictureBox webServiceState;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

