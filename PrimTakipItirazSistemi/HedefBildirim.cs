using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimTakipItirazSistemi
{
    public partial class HedefBildirim : Form
    {
        public HedefBildirim()
        {
            InitializeComponent();
        }

        private async void HedefBildirim_Load(object sender, EventArgs e)
        {
           await HedefListele();
        }

        private async Task HedefListele()
        {
            try
            {
                using (SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu))
                {
                    await baglantim.OpenAsync();
                    string query = @"
                        SELECT TOP 20 
                            AsistanID,
                            NotificationDate AS 'Hedef Tarihi',
                            Message AS 'Hedef Açıklaması'
                        FROM 
                            HedefBildirimi
                        WHERE 
                            Message IS NOT NULL
                        ORDER BY 
                            ID DESC";

                    SqlDataAdapter verileriListele = new SqlDataAdapter(query, baglantim);
                    DataSet ds = new DataSet();
                    await Task.Run(() => verileriListele.Fill(ds));

                    if (ds.Tables.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("Veri bulunamadı.", "Prim Takip İtiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
        }
    }
}
