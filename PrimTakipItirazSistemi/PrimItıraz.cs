using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace PrimTakipItirazSistemi
{
    public partial class PrimItıraz : Form
    {
        private int sonPrimId;
        private int GirisYapanAsistanID = Form1.GirisYapanAsistanID;
        SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu);
        public PrimItıraz(int PrimId)
        {
            InitializeComponent();
            sonPrimId = PrimId;
            primId.Text = "Prim ID: " + sonPrimId;
        }
        string epostaAdresi = "";

        private string GetEpostaByAsistanID(int AsistanID)
        {
            string epostaAdresi = "";
            try
            {
                baglantim.Open();

                SqlCommand ekleKomutu2 = new SqlCommand("sp_GetEpostaByAsistanID", baglantim);
                ekleKomutu2.CommandType = CommandType.StoredProcedure;
                ekleKomutu2.Parameters.AddWithValue("@AsistanID", AsistanID);

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
        private void Gonder_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();

                
                // itiraz ekleme
                SqlCommand ekleKomutu = new SqlCommand("sp_PrimItıraz", baglantim);
                ekleKomutu.CommandType = CommandType.StoredProcedure;
                ekleKomutu.Parameters.AddWithValue("@AsistanID", GirisYapanAsistanID);
                ekleKomutu.Parameters.AddWithValue("@PrimID", sonPrimId);
                ekleKomutu.Parameters.AddWithValue("@ItirazDurumuID", 1);
                ekleKomutu.Parameters.AddWithValue("@ItirazAciklamasi", itirazAciklamasi.Text);
                
                ekleKomutu.ExecuteNonQuery();

                baglantim.Close();
                MessageBox.Show("Yeni Çağrı Kaydı Oluşturuldu", "Prim Takip Itiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"); // Gmail sunucusunu bağlantısı

                mail.From = new MailAddress("vtysprojectmail@gmail.com");
                mail.To.Add(GetEpostaByAsistanID(GirisYapanAsistanID));
                mail.Subject = "Prim Id = "+ sonPrimId + " olan prim itirazı";
                mail.Body = itirazAciklamasi.Text;

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


        private void itirazAciklamasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrimItıraz_Load(object sender, EventArgs e)
        {

        }
    }
}
