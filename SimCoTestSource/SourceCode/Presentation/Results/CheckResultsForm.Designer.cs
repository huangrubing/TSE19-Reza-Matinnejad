namespace MiLTester.SourceCode.Presentation.Results
{
    partial class CheckResultsForm
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
            this.lvBlocksCheckResults = new System.Windows.Forms.ListView();
            this.Check = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BlockName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BlockPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.lvParamsCheckResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenParam = new System.Windows.Forms.Button();
            this.btnOpenBlock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvBlocksCheckResults
            // 
            this.lvBlocksCheckResults.AutoArrange = false;
            this.lvBlocksCheckResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Check,
            this.BlockName,
            this.BlockPath});
            this.lvBlocksCheckResults.FullRowSelect = true;
            this.lvBlocksCheckResults.GridLines = true;
            this.lvBlocksCheckResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBlocksCheckResults.HideSelection = false;
            this.lvBlocksCheckResults.Location = new System.Drawing.Point(12, 23);
            this.lvBlocksCheckResults.MultiSelect = false;
            this.lvBlocksCheckResults.Name = "lvBlocksCheckResults";
            this.lvBlocksCheckResults.Size = new System.Drawing.Size(527, 117);
            this.lvBlocksCheckResults.TabIndex = 65;
            this.lvBlocksCheckResults.UseCompatibleStateImageBehavior = false;
            this.lvBlocksCheckResults.View = System.Windows.Forms.View.Details;
            this.lvBlocksCheckResults.DoubleClick += new System.EventHandler(this.lvCheckResults_DoubleClick);
            // 
            // Check
            // 
            this.Check.Text = "Check";
            this.Check.Width = 145;
            // 
            // BlockName
            // 
            this.BlockName.Text = "Block Name";
            this.BlockName.Width = 112;
            // 
            // BlockPath
            // 
            this.BlockPath.Text = "Block Path";
            this.BlockPath.Width = 264;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(464, 325);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 66;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvParamsCheckResults
            // 
            this.lvParamsCheckResults.AutoArrange = false;
            this.lvParamsCheckResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvParamsCheckResults.FullRowSelect = true;
            this.lvParamsCheckResults.GridLines = true;
            this.lvParamsCheckResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvParamsCheckResults.HideSelection = false;
            this.lvParamsCheckResults.Location = new System.Drawing.Point(12, 190);
            this.lvParamsCheckResults.MultiSelect = false;
            this.lvParamsCheckResults.Name = "lvParamsCheckResults";
            this.lvParamsCheckResults.Size = new System.Drawing.Size(527, 131);
            this.lvParamsCheckResults.TabIndex = 67;
            this.lvParamsCheckResults.UseCompatibleStateImageBehavior = false;
            this.lvParamsCheckResults.View = System.Windows.Forms.View.Details;
            this.lvParamsCheckResults.DoubleClick += new System.EventHandler(this.lvParamsCheckResults_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Check";
            this.columnHeader1.Width = 145;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Block Name";
            this.columnHeader2.Width = 112;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Block Path";
            this.columnHeader3.Width = 264;
            // 
            // btnOpenParam
            // 
            this.btnOpenParam.Location = new System.Drawing.Point(12, 323);
            this.btnOpenParam.Name = "btnOpenParam";
            this.btnOpenParam.Size = new System.Drawing.Size(100, 23);
            this.btnOpenParam.TabIndex = 68;
            this.btnOpenParam.Text = "Highlight in Model";
            this.btnOpenParam.UseVisualStyleBackColor = true;
            this.btnOpenParam.Click += new System.EventHandler(this.btnOpenParam_Click);
            // 
            // btnOpenBlock
            // 
            this.btnOpenBlock.Location = new System.Drawing.Point(12, 145);
            this.btnOpenBlock.Name = "btnOpenBlock";
            this.btnOpenBlock.Size = new System.Drawing.Size(100, 23);
            this.btnOpenBlock.TabIndex = 69;
            this.btnOpenBlock.Text = "Highlight in Model";
            this.btnOpenBlock.UseVisualStyleBackColor = true;
            this.btnOpenBlock.Click += new System.EventHandler(this.btnOpenBlock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 16);
            this.label1.TabIndex = 70;
            this.label1.Text = "Sanity Check Results for Model Blocks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 16);
            this.label2.TabIndex = 71;
            this.label2.Text = "Sanity Check Results for Configuration Parameters:";
            // 
            // CheckResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 349);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenBlock);
            this.Controls.Add(this.btnOpenParam);
            this.Controls.Add(this.lvParamsCheckResults);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvBlocksCheckResults);
            this.Name = "CheckResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanity Check Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvBlocksCheckResults;
        private System.Windows.Forms.ColumnHeader Check;
        private System.Windows.Forms.ColumnHeader BlockName;
        private System.Windows.Forms.ColumnHeader BlockPath;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvParamsCheckResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnOpenParam;
        private System.Windows.Forms.Button btnOpenBlock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}