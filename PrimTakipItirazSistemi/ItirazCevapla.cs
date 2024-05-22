using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrimTakipItirazSistemi
{
    public partial class ItirazCevapla : Form
    {
        private int itirazID;

        public ItirazCevapla(int itirazID)
        {
            InitializeComponent();
            this.itirazID = itirazID;
        }

        private void ItirazCevapla_Load(object sender, EventArgs e)
        {
            // İtiraz detaylarını yükleme kodu buraya gelecek
        }

        private void buttonGonder_Click(object sender, EventArgs e)
        {
            string itirazCevabi = textBoxCevap.Text;
            string itirazDurumu = comboBoxDurum.SelectedItem.ToString();

            try
            {
                using (SqlConnection baglantim = new SqlConnection("Data Source=MONSTER\\SQLEXPRESS; Initial Catalog=PrimTakipItirazSistemi; Integrated Security=True; TrustServerCertificate=True"))
                {
                    string query = @"
                        UPDATE Itirazlar 
                        SET ItirazCevabi = @ItirazCevabi, 
                            ItirazDurumuID = (SELECT ItirazDurumuId FROM ItirazDurumlari WHERE DurumAdi = @DurumAdi)
                        WHERE ItirazID = @ItirazID";

                    using (SqlCommand cmd = new SqlCommand(query, baglantim))
                    {
                        cmd.Parameters.AddWithValue("@ItirazCevabi", itirazCevabi);
                        cmd.Parameters.AddWithValue("@DurumAdi", itirazDurumu);
                        cmd.Parameters.AddWithValue("@ItirazID", itirazID);

                        baglantim.Open();
                        cmd.ExecuteNonQuery();
                        baglantim.Close();
                    }

                    // E-posta gönderme işlemi buraya eklenecek
                }

                MessageBox.Show("İtiraz durumu başarıyla güncellendi.", "Prim Takip İtiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prim Takip İtiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
