namespace PrimTakipItirazSistemi
{
    partial class ItirazCevapla
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
            this.textBoxCevap = new System.Windows.Forms.TextBox();
            this.comboBoxDurum = new System.Windows.Forms.ComboBox();
            this.buttonGonder = new System.Windows.Forms.Button();
            this.labelCevap = new System.Windows.Forms.Label();
            this.labelDurum = new System.Windows.Forms.Label();
            this.primTakipItirazSistemiDataSet1 = new PrimTakipItirazSistemi.PrimTakipItirazSistemiDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.primTakipItirazSistemiDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCevap
            // 
            this.textBoxCevap.Location = new System.Drawing.Point(15, 25);
            this.textBoxCevap.Multiline = true;
            this.textBoxCevap.Name = "textBoxCevap";
            this.textBoxCevap.Size = new System.Drawing.Size(360, 100);
            this.textBoxCevap.TabIndex = 0;
            // 
            // comboBoxDurum
            // 
            this.comboBoxDurum.FormattingEnabled = true;
            this.comboBoxDurum.Items.AddRange(new object[] {
            "Onaylandı",
            "Reddedildi"});
            this.comboBoxDurum.Location = new System.Drawing.Point(15, 150);
            this.comboBoxDurum.Name = "comboBoxDurum";
            this.comboBoxDurum.Size = new System.Drawing.Size(360, 21);
            this.comboBoxDurum.TabIndex = 1;
            // 
            // buttonGonder
            // 
            this.buttonGonder.Location = new System.Drawing.Point(300, 190);
            this.buttonGonder.Name = "buttonGonder";
            this.buttonGonder.Size = new System.Drawing.Size(75, 23);
            this.buttonGonder.TabIndex = 2;
            this.buttonGonder.Text = "Gönder";
            this.buttonGonder.UseVisualStyleBackColor = true;
            this.buttonGonder.Click += new System.EventHandler(this.buttonGonder_Click);
            // 
            // labelCevap
            // 
            this.labelCevap.AutoSize = true;
            this.labelCevap.Location = new System.Drawing.Point(12, 9);
            this.labelCevap.Name = "labelCevap";
            this.labelCevap.Size = new System.Drawing.Size(82, 13);
            this.labelCevap.TabIndex = 3;
            this.labelCevap.Text = "İtiraz Açıklaması";
            // 
            // labelDurum
            // 
            this.labelDurum.AutoSize = true;
            this.labelDurum.Location = new System.Drawing.Point(12, 134);
            this.labelDurum.Name = "labelDurum";
            this.labelDurum.Size = new System.Drawing.Size(69, 13);
            this.labelDurum.TabIndex = 4;
            this.labelDurum.Text = "İtiraz Durumu";
            // 
            // primTakipItirazSistemiDataSet1
            // 
            this.primTakipItirazSistemiDataSet1.DataSetName = "PrimTakipItirazSistemiDataSet";
            this.primTakipItirazSistemiDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ItirazCevapla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 225);
            this.Controls.Add(this.labelDurum);
            this.Controls.Add(this.labelCevap);
            this.Controls.Add(this.buttonGonder);
            this.Controls.Add(this.comboBoxDurum);
            this.Controls.Add(this.textBoxCevap);
            this.Name = "ItirazCevapla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İtiraz Cevapla";
            this.Load += new System.EventHandler(this.ItirazCevapla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.primTakipItirazSistemiDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCevap;
        private System.Windows.Forms.ComboBox comboBoxDurum;
        private System.Windows.Forms.Button buttonGonder;
        private System.Windows.Forms.Label labelCevap;
        private System.Windows.Forms.Label labelDurum;
        private PrimTakipItirazSistemiDataSet primTakipItirazSistemiDataSet1;
    }
}
