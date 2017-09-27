namespace MiLTester.SourceCode.Presentation
{
    partial class SoftwareModeForm
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
            this.rbNormalMode = new System.Windows.Forms.RadioButton();
            this.rbMaintainanceMode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbNormalMode
            // 
            this.rbNormalMode.AutoSize = true;
            this.rbNormalMode.Checked = true;
            this.rbNormalMode.Location = new System.Drawing.Point(14, 27);
            this.rbNormalMode.Name = "rbNormalMode";
            this.rbNormalMode.Size = new System.Drawing.Size(88, 17);
            this.rbNormalMode.TabIndex = 0;
            this.rbNormalMode.TabStop = true;
            this.rbNormalMode.Text = "Normal Mode";
            this.rbNormalMode.UseVisualStyleBackColor = true;
            // 
            // rbMaintainanceMode
            // 
            this.rbMaintainanceMode.AutoSize = true;
            this.rbMaintainanceMode.Location = new System.Drawing.Point(112, 27);
            this.rbMaintainanceMode.Name = "rbMaintainanceMode";
            this.rbMaintainanceMode.Size = new System.Drawing.Size(117, 17);
            this.rbMaintainanceMode.TabIndex = 1;
            this.rbMaintainanceMode.Text = "Maintenance Mode";
            this.rbMaintainanceMode.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNormalMode);
            this.groupBox1.Controls.Add(this.rbMaintainanceMode);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Software Mode";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(95, 66);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 20);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Start";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 20);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SoftwareModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(237, 89);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SoftwareModeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Mode";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbNormalMode;
        private System.Windows.Forms.RadioButton rbMaintainanceMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}