using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimTakipItirazSistemi
{
    public partial class PrimHesaplat : Form
    {
        public PrimHesaplat()
        {
            InitializeComponent();
        }

        private void PrimHesaplat_Load(object sender, EventArgs e)
        {
            // Ayları comboBox1'e ekle
            comboBox1.Items.AddRange(new string[] { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" });

            // Yılları comboBox2'ye ekle
            for (int yil = DateTime.Now.Year - 5; yil <= DateTime.Now.Year ; yil++)
            {
                comboBox2.Items.Add(yil.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                int ay = comboBox1.SelectedIndex + 1; // Aylar 0'dan başladığı için 1 ekliyoruz
                int yil = Convert.ToInt32(comboBox2.SelectedItem);
                SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu);
                try
                {
                    
                    baglantim.Open();


                    // itiraz ekleme
                    SqlCommand ekleKomutu = new SqlCommand("sp_TumAsistanlarIcinPrimHesapla", baglantim);
                    ekleKomutu.CommandType = CommandType.StoredProcedure;
                    ekleKomutu.Parameters.AddWithValue("@Year", yil);
                    ekleKomutu.Parameters.AddWithValue("@Month", ay);

                    ekleKomutu.ExecuteNonQuery();

                    baglantim.Close();
                    MessageBox.Show("Prim Hesaplama İşlemi GErçekleştirildi", "Prim Takip Itiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message);
                    baglantim.Close();
                }
            }
        }
    }
}
