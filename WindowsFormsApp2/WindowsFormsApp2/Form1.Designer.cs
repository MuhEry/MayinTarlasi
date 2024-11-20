namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toplamMayınLabel = new System.Windows.Forms.Label();
            this.kalanHamleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(90, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 615);
            this.panel1.TabIndex = 0;
            // 
            // toplamMayınLabel
            // 
            this.toplamMayınLabel.AutoSize = true;
            this.toplamMayınLabel.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplamMayınLabel.Location = new System.Drawing.Point(85, 20);
            this.toplamMayınLabel.Name = "toplamMayınLabel";
            this.toplamMayınLabel.Size = new System.Drawing.Size(219, 33);
            this.toplamMayınLabel.TabIndex = 1;
            this.toplamMayınLabel.Text = "Toplam Mayın";
            // 
            // kalanHamleLabel
            // 
            this.kalanHamleLabel.AutoSize = true;
            this.kalanHamleLabel.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kalanHamleLabel.Location = new System.Drawing.Point(498, 20);
            this.kalanHamleLabel.Name = "kalanHamleLabel";
            this.kalanHamleLabel.Size = new System.Drawing.Size(198, 33);
            this.kalanHamleLabel.TabIndex = 2;
            this.kalanHamleLabel.Text = "Kalan Hücre:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 753);
            this.Controls.Add(this.kalanHamleLabel);
            this.Controls.Add(this.toplamMayınLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mayın Tarlası";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label toplamMayınLabel;
        private System.Windows.Forms.Label kalanHamleLabel;
    }
}

