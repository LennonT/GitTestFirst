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
            this.ReadBtn = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ToResxBtn = new System.Windows.Forms.Button();
            this.CheckBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadBtn
            // 
            this.ReadBtn.Location = new System.Drawing.Point(79, 63);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadBtn.TabIndex = 0;
            this.ReadBtn.Text = "读取excel";
            this.ReadBtn.UseVisualStyleBackColor = true;
            this.ReadBtn.Click += new System.EventHandler(this.ReadExcelBtn_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(79, 121);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(1247, 397);
            this.dgv.TabIndex = 1;
            // 
            // ToResxBtn
            // 
            this.ToResxBtn.Location = new System.Drawing.Point(412, 63);
            this.ToResxBtn.Name = "ToResxBtn";
            this.ToResxBtn.Size = new System.Drawing.Size(75, 23);
            this.ToResxBtn.TabIndex = 2;
            this.ToResxBtn.Text = "转换到Resx";
            this.ToResxBtn.UseVisualStyleBackColor = true;
            this.ToResxBtn.Click += new System.EventHandler(this.ToResxBtn_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Location = new System.Drawing.Point(239, 63);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(75, 23);
            this.CheckBtn.TabIndex = 3;
            this.CheckBtn.Text = "检查内容";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // TanslateTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 551);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.ToResxBtn);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.ReadBtn);
            this.Name = "TanslateTool";
            this.Text = "TansCheck";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadBtn;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button ToResxBtn;
        private System.Windows.Forms.Button CheckBtn;
    }
}

