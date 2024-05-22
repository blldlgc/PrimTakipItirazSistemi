using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrimTakipItirazSistemi
{
    public partial class AsistanItirazlari : Form
    {
        public AsistanItirazlari()
        {
            InitializeComponent();
        }

        private void AsistanItirazlari_Load(object sender, EventArgs e)
        {
            ItirazlariGoster();
        }

        private void ItirazlariGoster()
        {
            try
            {
                using (SqlConnection baglantim = new SqlConnection("Data Source=MONSTER\\SQLEXPRESS; Initial Catalog=PrimTakipItirazSistemi; Integrated Security=True; TrustServerCertificate=True"))
                {
                    string query = @"
                        SELECT 
                            i.ItirazID,
                            i.PrimID AS [PrimID],
                            i.ItirazAciklamasi AS [İtiraz Açıklaması],
                            i.ItirazCevabi AS [İtiraz Cevabı],
                            d.DurumAdi AS [İtiraz Durumu]
                        FROM 
                            Itirazlar i
                        JOIN 
                            ItirazDurumlari d ON i.ItirazDurumuID = d.ItirazDurumuId
                        WHERE 
                            i.AsistanID = @AsistanID
                        ORDER BY ItirazID DESC";

                    SqlDataAdapter verileriListele = new SqlDataAdapter(query, baglantim);
                    verileriListele.SelectCommand.Parameters.AddWithValue("@AsistanID", Form1.GirisYapanAsistanID);
                    DataSet ds = new DataSet();
                    verileriListele.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prim Takip İtiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Buraya istediğiniz işlemleri ekleyebilirsiniz.
        }

        private void ButtonCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
