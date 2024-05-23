using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
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
                mail.To.Add("bdalgic11@gmail.com");
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
