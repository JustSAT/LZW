namespace LZW
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openImage = new System.Windows.Forms.Button();
            this.compress = new System.Windows.Forms.Button();
            this.decompress = new System.Windows.Forms.Button();
            this.openCopressed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openImage
            // 
            this.openImage.Location = new System.Drawing.Point(12, 12);
            this.openImage.Name = "openImage";
            this.openImage.Size = new System.Drawing.Size(75, 23);
            this.openImage.TabIndex = 0;
            this.openImage.Text = "Открыть";
            this.openImage.UseVisualStyleBackColor = true;
            this.openImage.Click += new System.EventHandler(this.openImage_Click);
            // 
            // compress
            // 
            this.compress.Location = new System.Drawing.Point(93, 12);
            this.compress.Name = "compress";
            this.compress.Size = new System.Drawing.Size(75, 23);
            this.compress.TabIndex = 1;
            this.compress.Text = "Сжать";
            this.compress.UseVisualStyleBackColor = true;
            this.compress.Click += new System.EventHandler(this.compress_Click);
            // 
            // decompress
            // 
            this.decompress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.decompress.Location = new System.Drawing.Point(176, 12);
            this.decompress.Name = "decompress";
            this.decompress.Size = new System.Drawing.Size(75, 23);
            this.decompress.TabIndex = 2;
            this.decompress.Text = "Расжать";
            this.decompress.UseVisualStyleBackColor = true;
            this.decompress.Click += new System.EventHandler(this.decompress_Click);
            // 
            // openCopressed
            // 
            this.openCopressed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openCopressed.Location = new System.Drawing.Point(257, 12);
            this.openCopressed.Name = "openCopressed";
            this.openCopressed.Size = new System.Drawing.Size(75, 23);
            this.openCopressed.TabIndex = 3;
            this.openCopressed.Text = "Открыть";
            this.openCopressed.UseVisualStyleBackColor = true;
            this.openCopressed.Click += new System.EventHandler(this.openCopressed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 102);
            this.Controls.Add(this.openCopressed);
            this.Controls.Add(this.decompress);
            this.Controls.Add(this.compress);
            this.Controls.Add(this.openImage);
            this.MinimumSize = new System.Drawing.Size(360, 140);
            this.Name = "Form1";
            this.Text = "LZW main © Artem Shevchenko";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openImage;
        private System.Windows.Forms.Button compress;
        private System.Windows.Forms.Button decompress;
        private System.Windows.Forms.Button openCopressed;
    }
}

