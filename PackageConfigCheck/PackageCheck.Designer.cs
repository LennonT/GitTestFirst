namespace PackageConfigCheck
{
    partial class PackageCheck
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseBtn = new System.Windows.Forms.Button();
            this.PackageCheckBtn = new System.Windows.Forms.Button();
            this.ResultShowTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChooseBtn
            // 
            this.ChooseBtn.Location = new System.Drawing.Point(26, 36);
            this.ChooseBtn.Name = "ChooseBtn";
            this.ChooseBtn.Size = new System.Drawing.Size(75, 23);
            this.ChooseBtn.TabIndex = 0;
            this.ChooseBtn.Text = "选择";
            this.ChooseBtn.UseVisualStyleBackColor = true;
            this.ChooseBtn.Click += new System.EventHandler(this.ChooseBtn_Click);
            // 
            // PackageCheckBtn
            // 
            this.PackageCheckBtn.Location = new System.Drawing.Point(130, 36);
            this.PackageCheckBtn.Name = "PackageCheckBtn";
            this.PackageCheckBtn.Size = new System.Drawing.Size(75, 23);
            this.PackageCheckBtn.TabIndex = 1;
            this.PackageCheckBtn.Text = "检查";
            this.PackageCheckBtn.UseVisualStyleBackColor = true;
            this.PackageCheckBtn.Click += new System.EventHandler(this.PackageCheckBtn_Click);
            // 
            // ResultShowTextBox
            // 
            this.ResultShowTextBox.Location = new System.Drawing.Point(26, 100);
            this.ResultShowTextBox.Name = "ResultShowTextBox";
            this.ResultShowTextBox.Size = new System.Drawing.Size(334, 21);
            this.ResultShowTextBox.TabIndex = 2;
            // 
            // PackageCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 459);
            this.Controls.Add(this.ResultShowTextBox);
            this.Controls.Add(this.PackageCheckBtn);
            this.Controls.Add(this.ChooseBtn);
            this.Name = "PackageCheck";
            this.Text = "PackageCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChooseBtn;
        private System.Windows.Forms.Button PackageCheckBtn;
        private System.Windows.Forms.TextBox ResultShowTextBox;
    }
}

