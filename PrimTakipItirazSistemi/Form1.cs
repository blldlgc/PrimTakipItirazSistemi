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

namespace PrimTakipItirazSistemi
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		SqlConnection baglantim = new SqlConnection("Data Source=MONSTER\\SQLEXPRESS; Initial Catalog = PrimTakipItirazSistemi; Integrated Security=True; TrustServerCertificate=True");
		public static string tcno, adi, soyadi, yetki;
        //diğer sayfalarda id'leri kullanabilmek için static olarak tanımladık.
        public static int GirisYapanAsistanID; 
		public static int GirisYapanGrupYoneticiID;
		public static int GirisYapanLiderID;

        private void Form1_Load(object sender, EventArgs e)
		{
			this.Text = "Kullanıcı Girişi";// formun textini yani formun adını Kullanıcı Giriş yaprık. Bunu özellikler kısmında text yerinde yazabiliriz ama burdan anlatayım dedim.
			this.AcceptButton = button1; //enter tuşuna basılınca button1 çalışacak.
			this.CancelButton = button2;// esc tuşuna basılınca button2 çalışacak.
			label5.Text = Convert.ToString(hak);//kalan hakkı burada göreceğiz.Form ilk açıldığında 3 atadığımız için 3 olarak gözükücek.
			radioButton1.Checked = true;//radiobutton1 seçili gelicek.
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		}
		private void veriGetir()
		{
			tcno = kayıtokuma.GetValue(0).ToString();
			adi = kayıtokuma.GetValue(1).ToString();
			soyadi = kayıtokuma.GetValue(2).ToString();
			yetki = kayıtokuma.GetValue(3).ToString();
			kul_adi = kayıtokuma.GetValue(4).ToString();
			parola = kayıtokuma.GetValue(5).ToString();
		}
		SqlDataReader kayıtokuma;
		int hak = 3;// giriş hakkını kontrol edebilmek için hak adında bir değişken tanımladık ve değerini 3 olarak atadık

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int GetAsistanID(string kullaniciAdi)
        {
            int asistanID = -1; // Eğer eşleşen kullanıcı adı bulunamazsa -1 döndürülecek

            try
            {
				baglantim.Close(); // Bağlantıyı kapat
                baglantim.Open(); // Veritabanı bağlantısını aç

                // SQL sorgusunu hazırlar
                string query = "SELECT AsistanID FROM Asistanlar WHERE KullaniciAdi = @KullaniciAdi";

                // SqlCommand nesnesi oluştur ve parametreleri atar
                SqlCommand command = new SqlCommand(query, baglantim);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                // SqlDataReader ile sorguyu çalıştır ve sonucu oku
                SqlDataReader reader = command.ExecuteReader();

                // Eğer bir sonuç bulunursa, AsistanID'yi alır
                if (reader.Read())
                {
                    asistanID = Convert.ToInt32(reader["AsistanID"]);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesajı göster
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapat
                baglantim.Close();
            }

            // AsistanID'yi döndür
            return asistanID;
        }

        // GrupYoneticiID'yi döndüren fonksiyon
        public int GetGrupYoneticiID(string kullaniciAdi)
        {
            int grupYoneticiID = -1; // Eğer eşleşen kullanıcı adı bulunamazsa -1 döndürülecek

            try
            {
                baglantim.Close(); // Bağlantıyı kapat
                baglantim.Open(); // Veritabanı bağlantısını aç

                // SQL sorgusunu hazırlar
                string query = "SELECT GrupYoneticiID FROM GrupYoneticileri WHERE KullaniciAdi = @KullaniciAdi";

                // SqlCommand nesnesi oluştur ve parametreleri atar
                SqlCommand command = new SqlCommand(query, baglantim);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                // SqlDataReader ile sorguyu çalıştır ve sonucu oku
                SqlDataReader reader = command.ExecuteReader();

                // Eğer bir sonuç bulunursa, GrupYoneticiID'yi alır
                if (reader.Read())
                {
                    grupYoneticiID = Convert.ToInt32(reader["GrupYoneticiID"]);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesajı göster
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapat
                baglantim.Close();
            }

            // GrupYoneticiID'yi döndür
            return grupYoneticiID;
        }

        // LiderID'yi döndüren fonksiyon
        public int GetLiderID(string kullaniciAdi)
        {
            int liderID = -1; // Eğer eşleşen kullanıcı adı bulunamazsa -1 döndürülecek

            try
            {
                baglantim.Close(); // Bağlantıyı kapat
                baglantim.Open(); // Veritabanı bağlantısını aç

                // SQL sorgusunu hazırlar
                string query = "SELECT TakimID FROM TakimLiderleri WHERE KullaniciAdi = @KullaniciAdi";

                // SqlCommand nesnesi oluştur ve parametreleri atar
                SqlCommand command = new SqlCommand(query, baglantim);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                // SqlDataReader ile sorguyu çalıştır ve sonucu oku
                SqlDataReader reader = command.ExecuteReader();

                // Eğer bir sonuç bulunursa, GrupYoneticiID'yi alır
                if (reader.Read())
                {
                    liderID = Convert.ToInt32(reader["TakimID"]);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesajı göster
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapat
                baglantim.Close();
            }

            // GrupYoneticiID'yi döndür
            return liderID;
        }

        bool durum = false;// giriş işlemi başarılıysa true, başarısızsa false olacak şekilde bool türünde bir değişken tanımladık.Şuan değeri false çünkü daha giriş yapılamadı.
		public static string kul_adi, parola;
		private void button1_Click(object sender, EventArgs e)
		{
			if (hak != 0)//eğer hakkımız 0'a eşit değilse yani giriş hakkımız varsa...
			{
				baglantim.Open();//veritabanı bağlantısını açıyoruz.
				SqlCommand selectsorgu = new SqlCommand("select * from kullanicilar", baglantim);// kullanicilar tablomuzun içindeki verileri çağırır. Buradaki * ın anlamı tüm verileri çağır demek.
				 kayıtokuma = selectsorgu.ExecuteReader();//sorgudan gelen verileri okumamızı sağlar.
				while (kayıtokuma.Read())//kayıt okunduysa...
				{
					if (radioButton1.Checked == true)// ve radiobutton1 yani yönetici seçiliyse...
					{
						if (kayıtokuma["kullaniciAdi"].ToString() == textBox1.Text && kayıtokuma["parola"].ToString() == textBox2.Text && kayıtokuma["yetki"].ToString() == "Yönetici")//Eğer kayıtokuma dan gelen kullanıcı adı textbox1 ile, parola textbox2 ile ve yetki Yönetici ye eşitse...
						{
							durum = true;// giriş başarılı olduğu için durumu true olarak atadık.
							tcno = kayıtokuma.GetValue(0).ToString();//Bütün durumlar sağlandığı için tcno yu accessin ilk alanına yani tcno alanında aktardık.(Bilgisayarda sayma işlemleri 0 dan başlıyor bu yüzden tcno 0. alan)
							adi = kayıtokuma.GetValue(1).ToString();//adı sql in 1. alanına aktardık
							soyadi = kayıtokuma.GetValue(2).ToString();// soyadı sql in 2. alanına aktardık.
							yetki = kayıtokuma.GetValue(3).ToString();// yetkiyi sql in 3. alanına aktardık.

							int yoneticiID = GetGrupYoneticiID(kul_adi);
                            GirisYapanAsistanID = yoneticiID;

							this.Hide();// Yönetici girişi başarılı olduğu için bu form kapanıcak ve yönetici formu açılacak. Yönetici formunu bunun alt satırına geçince yazıyoruz. Bunun için önce yeni bir form açmamız gerekli. Proje --> form ekle (Project --> add windows form) ile ekliyoruz.
							YöneticiPanel frmYonetici= new YöneticiPanel();
							frmYonetici.Show();
							break;

						}
					}
					if (radioButton2.Checked == true)//Eğer radiobuttın2 seçiliyse...
					{
						if (kayıtokuma["kullaniciAdi"].ToString() == textBox1.Text && kayıtokuma["parola"].ToString() == textBox2.Text && kayıtokuma["yetki"].ToString() == "Takım Lideri")
						{
							durum = true;
							veriGetir();
                            int liderID = GetLiderID(kul_adi);
                            GirisYapanLiderID = liderID;

                            this.Hide();
							TakimLideriPanel frmTakimLideri= new TakimLideriPanel();
							frmTakimLideri.Show();

							break;
						}
					}
					if (radioButton3.Checked == true)//Eğer radiobuttın2 seçiliyse...
					{
						if (kayıtokuma["kullaniciAdi"].ToString() == textBox1.Text && kayıtokuma["parola"].ToString() == textBox2.Text && kayıtokuma["yetki"].ToString() == "Asistan")
						{
							durum = true;
							veriGetir();
							int asistanID = GetAsistanID(kul_adi);
                            GirisYapanAsistanID = asistanID;

                            this.Hide();
							AsistanMenu asistanMenu = new AsistanMenu();
							asistanMenu.Show();

							break;
						}
					}
				}
				if (durum == false)//eğer durum hâlâ false ise yani ne yönetici ne de kullanıcı girişi yapılmadıysa...
				{
					hak--;// giriş hakkını bir bir düşür.
					baglantim.Close();// bağlantıyı kapat.
				}
				label5.Text = Convert.ToString(hak);//kalan hakkı gösterir.
				if (hak == 0)//eğer giriş yapılmadıysa ve giriş hakkı kalmadıysa...
				{
					button1.Enabled = false;//button1 i pasif yap
					MessageBox.Show("Giriş Hakkı Kalmadı", "Prim Takip İtiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);//Başlığı Kütüphane Otomasyonu olan böyle bir mesaj kutusu çıkar.
					this.Close();//formu kapatır.
				}
			}
		}
	}
}
