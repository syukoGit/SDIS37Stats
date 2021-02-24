
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutBtnOkCancel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxSound = new System.Windows.Forms.GroupBox();
            this.checkBoxMuteSound = new System.Windows.Forms.CheckBox();
            this.flowLayoutSound = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutBtnOkCancel.SuspendLayout();
            this.groupBoxSound.SuspendLayout();
            this.flowLayoutSound.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(399, 389);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(391, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(369, 578);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxSound, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 357);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutMain.Controls.Add(this.tableLayoutBtnOkCancel, 0, 1);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMain.Size = new System.Drawing.Size(405, 424);
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
            this.tableLayoutBtnOkCancel.Location = new System.Drawing.Point(0, 395);
            this.tableLayoutBtnOkCancel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBtnOkCancel.Name = "tableLayoutBtnOkCancel";
            this.tableLayoutBtnOkCancel.RowCount = 1;
            this.tableLayoutBtnOkCancel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBtnOkCancel.Size = new System.Drawing.Size(405, 29);
            this.tableLayoutBtnOkCancel.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.Location = new System.Drawing.Point(266, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "&Valider";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.Location = new System.Drawing.Point(63, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxSound
            // 
            this.groupBoxSound.AutoSize = true;
            this.groupBoxSound.Controls.Add(this.flowLayoutSound);
            this.groupBoxSound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSound.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSound.Name = "groupBoxSound";
            this.groupBoxSound.Size = new System.Drawing.Size(379, 42);
            this.groupBoxSound.TabIndex = 0;
            this.groupBoxSound.TabStop = false;
            this.groupBoxSound.Text = "Son de l\'application";
            // 
            // checkBoxMuteSound
            // 
            this.checkBoxMuteSound.AutoSize = true;
            this.checkBoxMuteSound.Location = new System.Drawing.Point(3, 3);
            this.checkBoxMuteSound.Name = "checkBoxMuteSound";
            this.checkBoxMuteSound.Size = new System.Drawing.Size(146, 17);
            this.checkBoxMuteSound.TabIndex = 0;
            this.checkBoxMuteSound.Text = "Activer/Désactiver le son";
            this.checkBoxMuteSound.UseVisualStyleBackColor = true;
            // 
            // flowLayoutSound
            // 
            this.flowLayoutSound.AutoSize = true;
            this.flowLayoutSound.Controls.Add(this.checkBoxMuteSound);
            this.flowLayoutSound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutSound.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutSound.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutSound.Name = "flowLayoutSound";
            this.flowLayoutSound.Size = new System.Drawing.Size(373, 23);
            this.flowLayoutSound.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 424);
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.tableLayoutBtnOkCancel.ResumeLayout(false);
            this.groupBoxSound.ResumeLayout(false);
            this.groupBoxSound.PerformLayout();
            this.flowLayoutSound.ResumeLayout(false);
            this.flowLayoutSound.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxSound;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSound;
        private System.Windows.Forms.CheckBox checkBoxMuteSound;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBtnOkCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}