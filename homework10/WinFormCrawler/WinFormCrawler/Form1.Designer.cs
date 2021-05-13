using System;

namespace WinFormCrawler
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.startUrl_label = new System.Windows.Forms.Label();
            this.countUrl_label = new System.Windows.Forms.Label();
            this.startUrl_textBox = new System.Windows.Forms.TextBox();
            this.countUrl_textBox = new System.Windows.Forms.TextBox();
            this.resultUrl_textBox = new System.Windows.Forms.TextBox();
            this.crawl_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startUrl_label
            // 
            this.startUrl_label.AutoSize = true;
            this.startUrl_label.Location = new System.Drawing.Point(14, 11);
            this.startUrl_label.Name = "startUrl_label";
            this.startUrl_label.Size = new System.Drawing.Size(44, 18);
            this.startUrl_label.TabIndex = 0;
            this.startUrl_label.Text = "网站";
            // 
            // countUrl_label
            // 
            this.countUrl_label.AutoSize = true;
            this.countUrl_label.Location = new System.Drawing.Point(14, 42);
            this.countUrl_label.Name = "countUrl_label";
            this.countUrl_label.Size = new System.Drawing.Size(44, 18);
            this.countUrl_label.TabIndex = 1;
            this.countUrl_label.Text = "数量";
            this.countUrl_label.Click += new System.EventHandler(this.countUrl_label_Click);
            // 
            // startUrl_textBox
            // 
            this.startUrl_textBox.Location = new System.Drawing.Point(62, 7);
            this.startUrl_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startUrl_textBox.Name = "startUrl_textBox";
            this.startUrl_textBox.Size = new System.Drawing.Size(830, 28);
            this.startUrl_textBox.TabIndex = 2;
            // 
            // countUrl_textBox
            // 
            this.countUrl_textBox.Location = new System.Drawing.Point(62, 42);
            this.countUrl_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.countUrl_textBox.Name = "countUrl_textBox";
            this.countUrl_textBox.Size = new System.Drawing.Size(200, 28);
            this.countUrl_textBox.TabIndex = 3;
            // 
            // resultUrl_textBox
            // 
            this.resultUrl_textBox.Location = new System.Drawing.Point(269, 42);
            this.resultUrl_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resultUrl_textBox.Multiline = true;
            this.resultUrl_textBox.Name = "resultUrl_textBox";
            this.resultUrl_textBox.Size = new System.Drawing.Size(617, 483);
            this.resultUrl_textBox.TabIndex = 4;
            this.resultUrl_textBox.TextChanged += new System.EventHandler(this.resultUrl_textBox_TextChanged);
            // 
            // crawl_button
            // 
            this.crawl_button.Font = new System.Drawing.Font("宋体", 99F);
            this.crawl_button.Location = new System.Drawing.Point(17, 79);
            this.crawl_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.crawl_button.Name = "crawl_button";
            this.crawl_button.Size = new System.Drawing.Size(245, 446);
            this.crawl_button.TabIndex = 5;
            this.crawl_button.Text = "爬";
            this.crawl_button.UseVisualStyleBackColor = true;
            this.crawl_button.Click += new System.EventHandler(this.crawl_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.crawl_button);
            this.Controls.Add(this.resultUrl_textBox);
            this.Controls.Add(this.countUrl_textBox);
            this.Controls.Add(this.startUrl_textBox);
            this.Controls.Add(this.countUrl_label);
            this.Controls.Add(this.startUrl_label);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void resultUrl_textBox_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.Label startUrl_label;
        private System.Windows.Forms.Label countUrl_label;
        private System.Windows.Forms.TextBox startUrl_textBox;
        private System.Windows.Forms.TextBox countUrl_textBox;
        private System.Windows.Forms.TextBox resultUrl_textBox;
        private System.Windows.Forms.Button crawl_button;
    }
}

