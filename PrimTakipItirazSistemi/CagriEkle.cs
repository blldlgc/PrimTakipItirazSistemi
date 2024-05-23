using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrimTakipItirazSistemi
{
	public partial class CagriEkle : Form
	{
		public CagriEkle()
		{
			InitializeComponent();
            
        }
        

        SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu);
		private void temzile()//nesneleri temizler
		{
			textBox1.Clear(); textBox2.Clear(); mtbBaslangicSaati.Clear(); mtbBitisSaati.Clear(); comboBox1.Text=""; comboBox2.Text = "";
		}
        private void verileriGoster()
        {
            try
            {
                baglantim.Open(); // bağlantıyı aç
                SqlDataAdapter verilerilistele = new SqlDataAdapter(
                    "SELECT [Müşteri Adı], [Müşteri Soyadı], [Görüşme Tarihi], [Başlangıç Saati], [Bitiş Saati], [Görüşme Konusu], [Görüşme Durumu], [Çağrı ID] " +
                    "FROM vw_CagriAra " +
                    "ORDER BY [Çağrı ID] DESC", 
                    baglantim);

                DataSet dshafıza = new DataSet(); // verileri gruplandırmak için DataSet'i çağırdık
                verilerilistele.Fill(dshafıza); // verileri doldurduk
                dataGridView1.DataSource = dshafıza.Tables[0]; // DataGrid'e verileri ekledik
                baglantim.Close(); // bağlantıyı kapattık
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "Prim Takip İtiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error); // hata mesajını göster
                baglantim.Close(); // bağlantı kapanmazsa burada kapat
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void btnCikis_Click(object sender, EventArgs e)
		{
			this.Hide();
			AsistanMenu asistanMenu = new AsistanMenu();
			asistanMenu.Show();
		}

		private void CagriEkle_Load(object sender, EventArgs e)
		{
           
			verileriGoster();
        }

		private void btnTemizle_Click(object sender, EventArgs e)
		{
			temzile();
		}
        int GirisYapanAsistanID = Form1.GirisYapanAsistanID;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Arıza")
            {
                label10.Text = "1";
            }
            if (comboBox1.Text == "Talep")
            {
                label10.Text = "2";
            }
            if (comboBox1.Text == "Bilgi")
            {
                label10.Text = "3";
            }
            if (comboBox2.Text == "Tamamlandı.")
            {
                label11.Text = "1";
            }
            if (comboBox2.Text == "Takip Ediliyor.")
            {
                label11.Text = "2";
            }
            if (comboBox2.Text == "Sorun Çözülemedi.")
            {
                label11.Text = "3";
            }

            if (textBox1.Text.Length < 11 || textBox1.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.White;

            if (textBox2.Text == "" || textBox2.Text.Length < 2)
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.White;

            if (!TimeSpan.TryParse(mtbBaslangicSaati.Text, out TimeSpan baslangicSaati))
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = Color.White;

            if (!TimeSpan.TryParse(mtbBitisSaati.Text, out TimeSpan bitisSaati))
                label5.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.White;

            if (comboBox1.Text == "")
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.White;

            if (comboBox2.Text == "")
                label7.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.White;

            if (textBox1.Text != "" && textBox2.Text != "" && baslangicSaati != default && bitisSaati != default && comboBox1.Text != "" && comboBox2.Text != "")
            {
                try
                {
                    baglantim.Open();

                    // Müşteri ekleme ve MusteriID'yi alma
                    SqlCommand musteriEkleKomutu = new SqlCommand("INSERT INTO Musteriler (Musteri_Ad, Musteri_Soyad) OUTPUT INSERTED.MusteriID VALUES (@Musteri_Ad, @Musteri_Soyad)", baglantim);
                    musteriEkleKomutu.Parameters.AddWithValue("@Musteri_Ad", textBox1.Text);
                    musteriEkleKomutu.Parameters.AddWithValue("@Musteri_Soyad", textBox2.Text);
                    int musteriID = (int)musteriEkleKomutu.ExecuteScalar();

                    // Çağrı ekleme
                    SqlCommand ekleKomutu = new SqlCommand("sp_AddCustomerCall", baglantim);
                    ekleKomutu.CommandType = CommandType.StoredProcedure;
                    ekleKomutu.Parameters.AddWithValue("@AsistanID", GirisYapanAsistanID);
                    ekleKomutu.Parameters.AddWithValue("@MusteriID", musteriID);
                    ekleKomutu.Parameters.AddWithValue("@GorusmeKonusuID", Convert.ToInt32(label10.Text));
                    ekleKomutu.Parameters.AddWithValue("@GorusmeTarihi", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    ekleKomutu.Parameters.AddWithValue("@BaslangicSaati", baslangicSaati);
                    ekleKomutu.Parameters.AddWithValue("@BitisSaati", bitisSaati);
                    ekleKomutu.Parameters.AddWithValue("@GorusmeDurumuID", label11.Text);
                    ekleKomutu.ExecuteNonQuery();

                    baglantim.Close();
                    MessageBox.Show("Yeni Çağrı Kaydı Oluşturuldu", "Prim Takip Itiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    verileriGoster();
                    temzile();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message);
                    baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Yazı Rengi Kırmızı Olan Alanları Yeniden Gözden Geçiriniz.", "Prim Takip İtiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
			textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
			dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
			mtbBaslangicSaati.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
			mtbBitisSaati.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
			comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
			comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
