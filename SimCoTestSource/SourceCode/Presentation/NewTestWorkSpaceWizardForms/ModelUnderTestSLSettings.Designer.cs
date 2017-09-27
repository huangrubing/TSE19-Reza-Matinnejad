namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    partial class ModelUnderTestSLSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelUnderTestSLSettings));
            this.cmbPortNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnExclude = new System.Windows.Forms.Button();
            this.cmbPortNums = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPortNames
            // 
            this.cmbPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortNames.FormattingEnabled = true;
            this.cmbPortNames.Location = new System.Drawing.Point(101, 14);
            this.cmbPortNames.Name = "cmbPortNames";
            this.cmbPortNames.Size = new System.Drawing.Size(180, 21);
            this.cmbPortNames.TabIndex = 65;
            this.cmbPortNames.SelectedIndexChanged += new System.EventHandler(this.cmbPortNames_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Output:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(54, 163);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 25);
            this.btnStart.TabIndex = 63;
            this.btnStart.Text = "Start Test";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(131, 163);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(73, 25);
            this.btnPrevious.TabIndex = 62;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(208, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 25);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(209, 73);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(72, 23);
            this.btnApply.TabIndex = 67;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnExclude
            // 
            this.btnExclude.Location = new System.Drawing.Point(209, 102);
            this.btnExclude.Name = "btnExclude";
            this.btnExclude.Size = new System.Drawing.Size(72, 23);
            this.btnExclude.TabIndex = 68;
            this.btnExclude.Text = "Exclude";
            this.btnExclude.UseVisualStyleBackColor = true;
            this.btnExclude.Click += new System.EventHandler(this.btnExclude_Click);
            // 
            // cmbPortNums
            // 
            this.cmbPortNums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbPortNums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortNums.FormattingEnabled = true;
            this.cmbPortNums.Location = new System.Drawing.Point(51, 14);
            this.cmbPortNums.Name = "cmbPortNums";
            this.cmbPortNums.Size = new System.Drawing.Size(45, 21);
            this.cmbPortNums.TabIndex = 66;
            this.cmbPortNums.SelectedIndexChanged += new System.EventHandler(this.cmbPortNums_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Test Generation Time:";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(122, 137);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(82, 20);
            this.tbTime.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Sec";
            // 
            // ModelUnderTestSBSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 192);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExclude);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cmbPortNums);
            this.Controls.Add(this.cmbPortNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModelUnderTestSBSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Generation Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPortNames;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnExclude;
        private System.Windows.Forms.ComboBox cmbPortNums;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label label3;
    }
}