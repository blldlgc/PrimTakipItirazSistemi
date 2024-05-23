namespace PrimTakipItirazSistemi
{
    partial class PrimItıraz
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
            this.itirazAciklamasi = new System.Windows.Forms.RichTextBox();
            this.GonderBtn = new System.Windows.Forms.Button();
            this.primId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // itirazAciklamasi
            // 
            this.itirazAciklamasi.Location = new System.Drawing.Point(120, 93);
            this.itirazAciklamasi.Name = "itirazAciklamasi";
            this.itirazAciklamasi.Size = new System.Drawing.Size(316, 123);
            this.itirazAciklamasi.TabIndex = 0;
            this.itirazAciklamasi.Text = "";
            this.itirazAciklamasi.TextChanged += new System.EventHandler(this.itirazAciklamasi_TextChanged);
            // 
            // GonderBtn
            // 
            this.GonderBtn.Location = new System.Drawing.Point(238, 248);
            this.GonderBtn.Name = "GonderBtn";
            this.GonderBtn.Size = new System.Drawing.Size(75, 23);
            this.GonderBtn.TabIndex = 1;
            this.GonderBtn.Text = "Gönder";
            this.GonderBtn.UseVisualStyleBackColor = true;
            this.GonderBtn.Click += new System.EventHandler(this.Gonder_Click);
            // 
            // primId
            // 
            this.primId.AutoSize = true;
            this.primId.Location = new System.Drawing.Point(238, 37);
            this.primId.Name = "primId";
            this.primId.Size = new System.Drawing.Size(0, 13);
            this.primId.TabIndex = 2;
            // 
            // PrimItıraz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 450);
            this.Controls.Add(this.primId);
            this.Controls.Add(this.GonderBtn);
            this.Controls.Add(this.itirazAciklamasi);
            this.Name = "PrimItıraz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrimItıraz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox itirazAciklamasi;
        private System.Windows.Forms.Button GonderBtn;
        private System.Windows.Forms.Label primId;
    }
}