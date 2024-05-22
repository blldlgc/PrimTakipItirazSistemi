namespace PrimTakipItirazSistemi
{
	partial class AsistanMenu
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
            this.cagriEkle = new System.Windows.Forms.Button();
            this.PrimListesi = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cagriEkle
            // 
            this.cagriEkle.Location = new System.Drawing.Point(427, 16);
            this.cagriEkle.Name = "cagriEkle";
            this.cagriEkle.Size = new System.Drawing.Size(111, 158);
            this.cagriEkle.TabIndex = 2;
            this.cagriEkle.Text = "cagriEkle";
            this.cagriEkle.UseVisualStyleBackColor = true;
            this.cagriEkle.Click += new System.EventHandler(this.CagriEkle_Click);
            // 
            // PrimListesi
            // 
            this.PrimListesi.Location = new System.Drawing.Point(593, 16);
            this.PrimListesi.Name = "PrimListesi";
            this.PrimListesi.Size = new System.Drawing.Size(111, 158);
            this.PrimListesi.TabIndex = 3;
            this.PrimListesi.Text = "Prim Listesi";
            this.PrimListesi.UseVisualStyleBackColor = true;
            this.PrimListesi.Click += new System.EventHandler(this.PrimListesi_click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = global::PrimTakipItirazSistemi.Properties.Resources._4298389_fotor_20240521163344;
            this.button2.Location = new System.Drawing.Point(231, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 158);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AsistanCagrilar_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::PrimTakipItirazSistemi.Properties.Resources.ayarlar_fotor_2024050914741;
            this.button1.Location = new System.Drawing.Point(36, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 158);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AsistanPanel_Click);
            // 
            // AsistanMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrimListesi);
            this.Controls.Add(this.cagriEkle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AsistanMenu";
            this.Text = "AsistanMenu";
            this.Load += new System.EventHandler(this.AsistanMenu_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cagriEkle;
        private System.Windows.Forms.Button PrimListesi;
    }
}