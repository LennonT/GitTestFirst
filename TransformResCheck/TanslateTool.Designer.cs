namespace TransformResCheck
{
    partial class TanslateTool
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
            this.ReadExcelBtn = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ToResxBtn = new System.Windows.Forms.Button();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.ReadResxBtn = new System.Windows.Forms.Button();
            this.CheckResxBtn = new System.Windows.Forms.Button();
            this.ToExcelBtn = new System.Windows.Forms.Button();
            this.TipTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadExcelBtn
            // 
            this.ReadExcelBtn.Location = new System.Drawing.Point(23, 20);
            this.ReadExcelBtn.Name = "ReadExcelBtn";
            this.ReadExcelBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadExcelBtn.TabIndex = 0;
            this.ReadExcelBtn.Text = "读取excel";
            this.ReadExcelBtn.UseVisualStyleBackColor = true;
            this.ReadExcelBtn.Click += new System.EventHandler(this.ReadExcelBtn_Click);
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(413, 20);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(969, 509);
            this.dgv.TabIndex = 1;
            // 
            // ToResxBtn
            // 
            this.ToResxBtn.Enabled = false;
            this.ToResxBtn.Location = new System.Drawing.Point(279, 20);
            this.ToResxBtn.Name = "ToResxBtn";
            this.ToResxBtn.Size = new System.Drawing.Size(75, 23);
            this.ToResxBtn.TabIndex = 2;
            this.ToResxBtn.Text = "转换到Resx";
            this.ToResxBtn.UseVisualStyleBackColor = true;
            this.ToResxBtn.Click += new System.EventHandler(this.ToResxBtn_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Location = new System.Drawing.Point(131, 20);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(106, 23);
            this.CheckBtn.TabIndex = 3;
            this.CheckBtn.Text = "检查Excel内容";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckExcelBtn_Click);
            // 
            // ReadResxBtn
            // 
            this.ReadResxBtn.Location = new System.Drawing.Point(24, 78);
            this.ReadResxBtn.Name = "ReadResxBtn";
            this.ReadResxBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadResxBtn.TabIndex = 4;
            this.ReadResxBtn.Text = "读取Resx";
            this.ReadResxBtn.UseVisualStyleBackColor = true;
            this.ReadResxBtn.Click += new System.EventHandler(this.ReadResxBtn_Click);
            // 
            // CheckResxBtn
            // 
            this.CheckResxBtn.Location = new System.Drawing.Point(129, 79);
            this.CheckResxBtn.Name = "CheckResxBtn";
            this.CheckResxBtn.Size = new System.Drawing.Size(108, 23);
            this.CheckResxBtn.TabIndex = 5;
            this.CheckResxBtn.Text = "检查Resx内容";
            this.CheckResxBtn.UseVisualStyleBackColor = true;
            this.CheckResxBtn.Click += new System.EventHandler(this.CheckResxBtn_Click);
            // 
            // ToExcelBtn
            // 
            this.ToExcelBtn.Location = new System.Drawing.Point(279, 78);
            this.ToExcelBtn.Name = "ToExcelBtn";
            this.ToExcelBtn.Size = new System.Drawing.Size(115, 23);
            this.ToExcelBtn.TabIndex = 6;
            this.ToExcelBtn.Text = "转换到Excel";
            this.ToExcelBtn.UseVisualStyleBackColor = true;
            this.ToExcelBtn.Click += new System.EventHandler(this.ToExcelBtn_Click);
            // 
            // TipTxtBox
            // 
            this.TipTxtBox.Location = new System.Drawing.Point(23, 121);
            this.TipTxtBox.Multiline = true;
            this.TipTxtBox.Name = "TipTxtBox";
            this.TipTxtBox.ReadOnly = true;
            this.TipTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TipTxtBox.Size = new System.Drawing.Size(371, 408);
            this.TipTxtBox.TabIndex = 7;
            // 
            // TanslateTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 551);
            this.Controls.Add(this.TipTxtBox);
            this.Controls.Add(this.ToExcelBtn);
            this.Controls.Add(this.CheckResxBtn);
            this.Controls.Add(this.ReadResxBtn);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.ToResxBtn);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.ReadExcelBtn);
            this.Name = "TanslateTool";
            this.Text = "TansCheck";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadExcelBtn;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button ToResxBtn;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button ReadResxBtn;
        private System.Windows.Forms.Button CheckResxBtn;
        private System.Windows.Forms.Button ToExcelBtn;
        private System.Windows.Forms.TextBox TipTxtBox;
    }
}

