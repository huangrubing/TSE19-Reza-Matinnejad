namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    partial class FunctionTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionTypeForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbWorkspaceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSimulink = new System.Windows.Forms.RadioButton();
            this.rbContinuousController = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbWorkspaceName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbSimulink);
            this.groupBox1.Controls.Add(this.rbContinuousController);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbWorkspaceName
            // 
            this.tbWorkspaceName.Location = new System.Drawing.Point(116, 19);
            this.tbWorkspaceName.Name = "tbWorkspaceName";
            this.tbWorkspaceName.Size = new System.Drawing.Size(271, 20);
            this.tbWorkspaceName.TabIndex = 5;
            this.tbWorkspaceName.Text = "WorkspaceName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Workspace Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Which type of function do you want to test?";
            // 
            // rbSimulink
            // 
            this.rbSimulink.AutoSize = true;
            this.rbSimulink.Checked = true;
            this.rbSimulink.Location = new System.Drawing.Point(52, 90);
            this.rbSimulink.Name = "rbSimulink";
            this.rbSimulink.Size = new System.Drawing.Size(160, 17);
            this.rbSimulink.TabIndex = 1;
            this.rbSimulink.TabStop = true;
            this.rbSimulink.Text = "Simulink/Stateflow Controller";
            this.rbSimulink.UseVisualStyleBackColor = true;
            // 
            // rbContinuousController
            // 
            this.rbContinuousController.AutoSize = true;
            this.rbContinuousController.Location = new System.Drawing.Point(52, 120);
            this.rbContinuousController.Name = "rbContinuousController";
            this.rbContinuousController.Size = new System.Drawing.Size(125, 17);
            this.rbContinuousController.TabIndex = 0;
            this.rbContinuousController.Text = "Continuous Controller";
            this.rbContinuousController.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(319, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(240, 176);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // FunctionTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 203);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FunctionTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Type of Model Under Test";
            this.Shown += new System.EventHandler(this.FunctionTypeForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.RadioButton rbSimulink;
        private System.Windows.Forms.RadioButton rbContinuousController;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWorkspaceName;
        private System.Windows.Forms.Label label2;
    }
}