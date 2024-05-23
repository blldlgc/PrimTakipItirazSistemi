using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Data;

namespace PrimTakipItirazSistemi
{
    public partial class ItirazCevapla : Form
    {
        private int itirazID;
        SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu);
        string epostaAdresi = "";
        private int girisYapanLiderID = Form1.GirisYapanLiderID;

        public ItirazCevapla(int itirazID)
        {
            InitializeComponent();
            this.itirazID = itirazID;
        }

        private void ItirazCevapla_Load(object sender, EventArgs e)
        {
            
        }

        private string GetGroupManagerEmailByTeamID(int TakimID)
        {
            string epostaAdresi = "";
            try
            {
                baglantim.Open();

                SqlCommand ekleKomutu2 = new SqlCommand("sp_GetGroupManagerEmailByTeamID", baglantim);
                ekleKomutu2.CommandType = CommandType.StoredProcedure;
                ekleKomutu2.Parameters.AddWithValue("@TakimID", TakimID);

                SqlDataReader dr = ekleKomutu2.ExecuteReader();
                if (dr.Read())
                {
                    epostaAdresi = dr["eposta"].ToString();
                }

                baglantim.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta adresini alırken bir hata oluştu: " + ex.Message);
            }
            return epostaAdresi;
        }

        private void buttonGonder_Click(object sender, EventArgs e)
        {
            string itirazCevabi = textBoxCevap.Text;
            string itirazDurumu = comboBoxDurum.SelectedItem.ToString();
            

            try
            {
                using (SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu))
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

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"); // Gmail sunucusunu bağlantısı

                mail.From = new MailAddress("vtysprojectmail@gmail.com");
                mail.To.Add(GetGroupManagerEmailByTeamID(girisYapanLiderID));
                mail.Subject = itirazID +"nolu itiraz cevabı";
                mail.Body = itirazID + " nolu itiraza cevabım: "+itirazCevabi + " İtiraz durumu: " + itirazDurumu;

                // Sunucu kimlik bilgilerini ayarlama
                SmtpServer.Port = 587; // Gmail için port numarası
                SmtpServer.Credentials = new NetworkCredential("vtysprojectmail@gmail.com", "fuul bsuj mcwf amva");
                SmtpServer.EnableSsl = true;

                // E-postayı gönderme
                SmtpServer.Send(mail);
                MessageBox.Show("E-posta başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
