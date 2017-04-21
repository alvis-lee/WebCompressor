namespace WebCompress
{
    partial class FrmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblCompletedCount = new System.Windows.Forms.Label();
            this.pbCompress = new System.Windows.Forms.ProgressBar();
            this.lblFailedCount = new System.Windows.Forms.Label();
            this.lblPrecent = new System.Windows.Forms.Label();
            this.cbCss = new System.Windows.Forms.CheckBox();
            this.cbJs = new System.Windows.Forms.CheckBox();
            this.cbHtml = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "压缩文件目录";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(111, 31);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(244, 23);
            this.txtPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(365, 30);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(87, 25);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Enabled = false;
            this.btnCompress.Location = new System.Drawing.Point(365, 69);
            this.btnCompress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(87, 33);
            this.btnCompress.TabIndex = 2;
            this.btnCompress.Text = "压缩";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(30, 118);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(32, 17);
            this.lblTotalCount.TabIndex = 3;
            this.lblTotalCount.Text = "总数";
            // 
            // lblCompletedCount
            // 
            this.lblCompletedCount.AutoSize = true;
            this.lblCompletedCount.Location = new System.Drawing.Point(142, 118);
            this.lblCompletedCount.Name = "lblCompletedCount";
            this.lblCompletedCount.Size = new System.Drawing.Size(32, 17);
            this.lblCompletedCount.TabIndex = 3;
            this.lblCompletedCount.Text = "成功";
            // 
            // pbCompress
            // 
            this.pbCompress.Location = new System.Drawing.Point(27, 151);
            this.pbCompress.Name = "pbCompress";
            this.pbCompress.Size = new System.Drawing.Size(327, 23);
            this.pbCompress.TabIndex = 4;
            // 
            // lblFailedCount
            // 
            this.lblFailedCount.AutoSize = true;
            this.lblFailedCount.Location = new System.Drawing.Point(254, 118);
            this.lblFailedCount.Name = "lblFailedCount";
            this.lblFailedCount.Size = new System.Drawing.Size(32, 17);
            this.lblFailedCount.TabIndex = 3;
            this.lblFailedCount.Text = "失败";
            // 
            // lblPrecent
            // 
            this.lblPrecent.AutoSize = true;
            this.lblPrecent.ForeColor = System.Drawing.Color.Red;
            this.lblPrecent.Location = new System.Drawing.Point(362, 154);
            this.lblPrecent.Name = "lblPrecent";
            this.lblPrecent.Size = new System.Drawing.Size(43, 17);
            this.lblPrecent.TabIndex = 5;
            this.lblPrecent.Text = "label2";
            // 
            // cbCss
            // 
            this.cbCss.AutoSize = true;
            this.cbCss.Checked = true;
            this.cbCss.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCss.Location = new System.Drawing.Point(200, 75);
            this.cbCss.Name = "cbCss";
            this.cbCss.Size = new System.Drawing.Size(45, 21);
            this.cbCss.TabIndex = 6;
            this.cbCss.Text = "css";
            this.cbCss.UseVisualStyleBackColor = true;
            // 
            // cbJs
            // 
            this.cbJs.AutoSize = true;
            this.cbJs.Checked = true;
            this.cbJs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbJs.Location = new System.Drawing.Point(255, 75);
            this.cbJs.Name = "cbJs";
            this.cbJs.Size = new System.Drawing.Size(36, 21);
            this.cbJs.TabIndex = 6;
            this.cbJs.Text = "js";
            this.cbJs.UseVisualStyleBackColor = true;
            // 
            // cbHtml
            // 
            this.cbHtml.AutoSize = true;
            this.cbHtml.Location = new System.Drawing.Point(301, 75);
            this.cbHtml.Name = "cbHtml";
            this.cbHtml.Size = new System.Drawing.Size(52, 21);
            this.cbHtml.TabIndex = 6;
            this.cbHtml.Text = "html";
            this.cbHtml.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 195);
            this.Controls.Add(this.cbHtml);
            this.Controls.Add(this.cbJs);
            this.Controls.Add(this.cbCss);
            this.Controls.Add(this.lblPrecent);
            this.Controls.Add(this.pbCompress);
            this.Controls.Add(this.lblFailedCount);
            this.Controls.Add(this.lblCompletedCount);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web前端压缩工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblCompletedCount;
        private System.Windows.Forms.ProgressBar pbCompress;
        private System.Windows.Forms.Label lblFailedCount;
        private System.Windows.Forms.Label lblPrecent;
        private System.Windows.Forms.CheckBox cbCss;
        private System.Windows.Forms.CheckBox cbJs;
        private System.Windows.Forms.CheckBox cbHtml;
    }
}

