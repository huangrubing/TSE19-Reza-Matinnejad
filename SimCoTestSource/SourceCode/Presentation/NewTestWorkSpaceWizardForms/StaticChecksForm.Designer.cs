namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    partial class StaticChecksForm
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
            this.checks = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.clbBlocks = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clbParams = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checks
            // 
            this.checks.Location = new System.Drawing.Point(12, 222);
            this.checks.Name = "checks";
            this.checks.Size = new System.Drawing.Size(91, 23);
            this.checks.TabIndex = 30;
            this.checks.Text = "Perform Checks";
            this.checks.UseVisualStyleBackColor = true;
            this.checks.Click += new System.EventHandler(this.checks_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(194, 223);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 29;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(351, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(273, 223);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // clbBlocks
            // 
            this.clbBlocks.CheckOnClick = true;
            this.clbBlocks.FormattingEnabled = true;
            this.clbBlocks.Items.AddRange(new object[] {
            "Check for blocks with \'Saturate on Integer Overflow\' not checked",
            "Check for From blocks without a corresponding Goto block",
            "Check for Goto blocks without a corresponding From block",
            "Check for Input or Ouputs without resolving to a Simulink Signal Object"});
            this.clbBlocks.Location = new System.Drawing.Point(11, 26);
            this.clbBlocks.Name = "clbBlocks";
            this.clbBlocks.Size = new System.Drawing.Size(415, 79);
            this.clbBlocks.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Sanity Checks for Model Blocks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Sanity Checks for Configuration Parameters:";
            // 
            // clbParams
            // 
            this.clbParams.CheckOnClick = true;
            this.clbParams.FormattingEnabled = true;
            this.clbParams.Items.AddRange(new object[] {
            "Check for calibration parameters with multiple values",
            "Check for calibration tables with one value",
            "Check for calibration tables with values all the same",
            "Check for calibration parameters with High smaller than Law"});
            this.clbParams.Location = new System.Drawing.Point(12, 130);
            this.clbParams.Name = "clbParams";
            this.clbParams.Size = new System.Drawing.Size(415, 79);
            this.clbParams.TabIndex = 35;
            // 
            // StaticChecksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 252);
            this.Controls.Add(this.clbParams);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checks);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.clbBlocks);
            this.Name = "StaticChecksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanity Checks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button checks;
        private System.Windows.Forms.CheckedListBox clbBlocks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbParams;
    }
}