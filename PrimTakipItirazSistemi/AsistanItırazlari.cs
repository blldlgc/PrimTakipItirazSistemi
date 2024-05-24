using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                using (SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu))
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

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Hücre rengini ayarlama
                        if (row.Cells["İtiraz Durumu"].Value != null)
                        {
                            if (row.Cells["İtiraz Durumu"].Value.ToString() == "Onaylandı")
                            {
                                row.Cells["İtiraz Durumu"].Style.BackColor = Color.Green;
                            }
                            else if (row.Cells["İtiraz Durumu"].Value.ToString() == "Reddedildi")
                            {
                                row.Cells["İtiraz Durumu"].Style.BackColor = Color.Red;
                            }
                            else if (row.Cells["İtiraz Durumu"].Value.ToString() == "Bekliyor")
                            {
                                row.Cells["İtiraz Durumu"].Style.BackColor = Color.Orange;
                            }
                        }
                    }
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
            AsistanMenu asistanMenu = new AsistanMenu();
            asistanMenu.Show();
        }
    }
}
