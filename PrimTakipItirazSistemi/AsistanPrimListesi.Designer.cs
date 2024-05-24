namespace PrimTakipItirazSistemi
{
    partial class AsistanPrimListesi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsistanPrimListesi));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.primItiraz = new System.Windows.Forms.Button();
            this.buttonCikis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(557, 290);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Son Prime İtiraz Et";
            // 
            // primItiraz
            // 
            this.primItiraz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.primItiraz.Image = ((System.Drawing.Image)(resources.GetObject("primItiraz.Image")));
            this.primItiraz.Location = new System.Drawing.Point(12, 28);
            this.primItiraz.Name = "primItiraz";
            this.primItiraz.Size = new System.Drawing.Size(124, 86);
            this.primItiraz.TabIndex = 5;
            this.primItiraz.UseVisualStyleBackColor = true;
            this.primItiraz.Click += new System.EventHandler(this.primItıraz_click);
            // 
            // buttonCikis
            // 
            this.buttonCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCikis.Image = global::PrimTakipItirazSistemi.Properties.Resources.home__2_;
            this.buttonCikis.Location = new System.Drawing.Point(501, -1);
            this.buttonCikis.Name = "buttonCikis";
            this.buttonCikis.Size = new System.Drawing.Size(82, 49);
            this.buttonCikis.TabIndex = 4;
            this.buttonCikis.UseVisualStyleBackColor = true;
            this.buttonCikis.Click += new System.EventHandler(this.ButtonCikis_Click);
            // 
            // AsistanPrimListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(581, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.primItiraz);
            this.Controls.Add(this.buttonCikis);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AsistanPrimListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AsistanPrimListesi";
            this.Load += new System.EventHandler(this.AsistanPrimListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCikis;
        private System.Windows.Forms.Button primItiraz;
        private System.Windows.Forms.Label label1;
    }
}
