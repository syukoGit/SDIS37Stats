
namespace SDIS37Stats.Controls
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxThemeType = new System.Windows.Forms.ComboBox();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutBtnOkCancel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxOperationView = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelNbOperationOfDepartmentDisplayed = new System.Windows.Forms.Label();
            this.labelNbOperationOfUserFirehouseDisplayed = new System.Windows.Forms.Label();
            this.nbOperationOfDepartmentDisplayed = new System.Windows.Forms.NumericUpDown();
            this.nbOperationOfUserFirehouseDisplayed = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSound = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxMuteSound = new System.Windows.Forms.CheckBox();
            this.groupBoxThemeAndColor = new System.Windows.Forms.GroupBox();
            this.tableLayoutTheme = new System.Windows.Forms.TableLayoutPanel();
            this.labelThemeType = new System.Windows.Forms.Label();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutBtnOkCancel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxOperationView.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbOperationOfDepartmentDisplayed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbOperationOfUserFirehouseDisplayed)).BeginInit();
            this.groupBoxSound.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxThemeAndColor.SuspendLayout();
            this.tableLayoutTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxThemeType
            // 
            this.comboBoxThemeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxThemeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThemeType.FormattingEnabled = true;
            this.comboBoxThemeType.Location = new System.Drawing.Point(55, 3);
            this.comboBoxThemeType.Name = "comboBoxThemeType";
            this.comboBoxThemeType.Size = new System.Drawing.Size(449, 21);
            this.comboBoxThemeType.TabIndex = 0;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.tableLayoutBtnOkCancel, 0, 1);
            this.tableLayoutMain.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMain.Size = new System.Drawing.Size(525, 539);
            this.tableLayoutMain.TabIndex = 1;
            // 
            // tableLayoutBtnOkCancel
            // 
            this.tableLayoutBtnOkCancel.AutoSize = true;
            this.tableLayoutBtnOkCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutBtnOkCancel.ColumnCount = 2;
            this.tableLayoutBtnOkCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBtnOkCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBtnOkCancel.Controls.Add(this.buttonOk, 1, 0);
            this.tableLayoutBtnOkCancel.Controls.Add(this.buttonCancel, 0, 0);
            this.tableLayoutBtnOkCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBtnOkCancel.Location = new System.Drawing.Point(0, 510);
            this.tableLayoutBtnOkCancel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBtnOkCancel.Name = "tableLayoutBtnOkCancel";
            this.tableLayoutBtnOkCancel.RowCount = 1;
            this.tableLayoutBtnOkCancel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBtnOkCancel.Size = new System.Drawing.Size(525, 29);
            this.tableLayoutBtnOkCancel.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.Location = new System.Drawing.Point(356, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "&Valider";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.Location = new System.Drawing.Point(93, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBoxOperationView);
            this.panel1.Controls.Add(this.groupBoxSound);
            this.panel1.Controls.Add(this.groupBoxThemeAndColor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(519, 504);
            this.panel1.TabIndex = 2;
            // 
            // groupBoxOperationView
            // 
            this.groupBoxOperationView.AutoSize = true;
            this.groupBoxOperationView.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxOperationView.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxOperationView.Location = new System.Drawing.Point(3, 91);
            this.groupBoxOperationView.Name = "groupBoxOperationView";
            this.groupBoxOperationView.Size = new System.Drawing.Size(513, 71);
            this.groupBoxOperationView.TabIndex = 2;
            this.groupBoxOperationView.TabStop = false;
            this.groupBoxOperationView.Text = "Affichage des interventions :";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.labelNbOperationOfDepartmentDisplayed, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelNbOperationOfUserFirehouseDisplayed, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.nbOperationOfDepartmentDisplayed, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.nbOperationOfUserFirehouseDisplayed, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(507, 52);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // labelNbOperationOfDepartmentDisplayed
            // 
            this.labelNbOperationOfDepartmentDisplayed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNbOperationOfDepartmentDisplayed.AutoSize = true;
            this.labelNbOperationOfDepartmentDisplayed.Location = new System.Drawing.Point(133, 6);
            this.labelNbOperationOfDepartmentDisplayed.Name = "labelNbOperationOfDepartmentDisplayed";
            this.labelNbOperationOfDepartmentDisplayed.Size = new System.Drawing.Size(166, 13);
            this.labelNbOperationOfDepartmentDisplayed.TabIndex = 0;
            this.labelNbOperationOfDepartmentDisplayed.Text = "Nombre d\'intervention  à afficher :";
            // 
            // labelNbOperationOfUserFirehouseDisplayed
            // 
            this.labelNbOperationOfUserFirehouseDisplayed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNbOperationOfUserFirehouseDisplayed.AutoSize = true;
            this.labelNbOperationOfUserFirehouseDisplayed.Location = new System.Drawing.Point(3, 32);
            this.labelNbOperationOfUserFirehouseDisplayed.Name = "labelNbOperationOfUserFirehouseDisplayed";
            this.labelNbOperationOfUserFirehouseDisplayed.Size = new System.Drawing.Size(296, 13);
            this.labelNbOperationOfUserFirehouseDisplayed.TabIndex = 1;
            this.labelNbOperationOfUserFirehouseDisplayed.Text = "Nombre d\'intervention de la caserne de l\'utilisateur à afficher :";
            // 
            // nbOperationOfDepartmentDisplayed
            // 
            this.nbOperationOfDepartmentDisplayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nbOperationOfDepartmentDisplayed.Location = new System.Drawing.Point(305, 3);
            this.nbOperationOfDepartmentDisplayed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbOperationOfDepartmentDisplayed.Name = "nbOperationOfDepartmentDisplayed";
            this.nbOperationOfDepartmentDisplayed.Size = new System.Drawing.Size(199, 20);
            this.nbOperationOfDepartmentDisplayed.TabIndex = 2;
            this.nbOperationOfDepartmentDisplayed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbOperationOfDepartmentDisplayed.ValueChanged += new System.EventHandler(this.NbOperationOfDepartmentDisplayed_ValueChanged);
            // 
            // nbOperationOfUserFirehouseDisplayed
            // 
            this.nbOperationOfUserFirehouseDisplayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nbOperationOfUserFirehouseDisplayed.Location = new System.Drawing.Point(305, 29);
            this.nbOperationOfUserFirehouseDisplayed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbOperationOfUserFirehouseDisplayed.Name = "nbOperationOfUserFirehouseDisplayed";
            this.nbOperationOfUserFirehouseDisplayed.Size = new System.Drawing.Size(199, 20);
            this.nbOperationOfUserFirehouseDisplayed.TabIndex = 3;
            this.nbOperationOfUserFirehouseDisplayed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbOperationOfUserFirehouseDisplayed.ValueChanged += new System.EventHandler(this.NbOperationOfUserFirehouseDisplayed_ValueChanged);
            // 
            // groupBoxSound
            // 
            this.groupBoxSound.AutoSize = true;
            this.groupBoxSound.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxSound.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSound.Location = new System.Drawing.Point(3, 49);
            this.groupBoxSound.Name = "groupBoxSound";
            this.groupBoxSound.Size = new System.Drawing.Size(513, 42);
            this.groupBoxSound.TabIndex = 1;
            this.groupBoxSound.TabStop = false;
            this.groupBoxSound.Text = "Sons";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxMuteSound, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 23);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxMuteSound
            // 
            this.checkBoxMuteSound.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxMuteSound.AutoSize = true;
            this.checkBoxMuteSound.Location = new System.Drawing.Point(3, 3);
            this.checkBoxMuteSound.Name = "checkBoxMuteSound";
            this.checkBoxMuteSound.Size = new System.Drawing.Size(90, 17);
            this.checkBoxMuteSound.TabIndex = 0;
            this.checkBoxMuteSound.Text = "Activer le son";
            this.checkBoxMuteSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMuteSound.UseVisualStyleBackColor = true;
            this.checkBoxMuteSound.CheckedChanged += new System.EventHandler(this.CheckBoxMuteSound_CheckedChanged);
            // 
            // groupBoxThemeAndColor
            // 
            this.groupBoxThemeAndColor.AutoSize = true;
            this.groupBoxThemeAndColor.Controls.Add(this.tableLayoutTheme);
            this.groupBoxThemeAndColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxThemeAndColor.Location = new System.Drawing.Point(3, 3);
            this.groupBoxThemeAndColor.Name = "groupBoxThemeAndColor";
            this.groupBoxThemeAndColor.Size = new System.Drawing.Size(513, 46);
            this.groupBoxThemeAndColor.TabIndex = 0;
            this.groupBoxThemeAndColor.TabStop = false;
            this.groupBoxThemeAndColor.Text = "Thèmes et couleurs";
            // 
            // tableLayoutTheme
            // 
            this.tableLayoutTheme.AutoSize = true;
            this.tableLayoutTheme.ColumnCount = 2;
            this.tableLayoutTheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutTheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTheme.Controls.Add(this.comboBoxThemeType, 1, 0);
            this.tableLayoutTheme.Controls.Add(this.labelThemeType, 0, 0);
            this.tableLayoutTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTheme.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutTheme.Name = "tableLayoutTheme";
            this.tableLayoutTheme.RowCount = 1;
            this.tableLayoutTheme.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutTheme.Size = new System.Drawing.Size(507, 27);
            this.tableLayoutTheme.TabIndex = 0;
            // 
            // labelThemeType
            // 
            this.labelThemeType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelThemeType.AutoSize = true;
            this.labelThemeType.Location = new System.Drawing.Point(3, 7);
            this.labelThemeType.Name = "labelThemeType";
            this.labelThemeType.Size = new System.Drawing.Size(46, 13);
            this.labelThemeType.TabIndex = 0;
            this.labelThemeType.Text = "Thème :";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 539);
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paramètres";
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.tableLayoutBtnOkCancel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxOperationView.ResumeLayout(false);
            this.groupBoxOperationView.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbOperationOfDepartmentDisplayed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbOperationOfUserFirehouseDisplayed)).EndInit();
            this.groupBoxSound.ResumeLayout(false);
            this.groupBoxSound.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxThemeAndColor.ResumeLayout(false);
            this.groupBoxThemeAndColor.PerformLayout();
            this.tableLayoutTheme.ResumeLayout(false);
            this.tableLayoutTheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBtnOkCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxThemeType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxSound;
        private System.Windows.Forms.GroupBox groupBoxThemeAndColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTheme;
        private System.Windows.Forms.Label labelThemeType;
        private System.Windows.Forms.CheckBox checkBoxMuteSound;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxOperationView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelNbOperationOfDepartmentDisplayed;
        private System.Windows.Forms.Label labelNbOperationOfUserFirehouseDisplayed;
        private System.Windows.Forms.NumericUpDown nbOperationOfDepartmentDisplayed;
        private System.Windows.Forms.NumericUpDown nbOperationOfUserFirehouseDisplayed;
    }
}