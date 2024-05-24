using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PrimTakipItirazSistemi
{
    public partial class HedefBildirim : Form
    {
        public HedefBildirim()
        {
            InitializeComponent();
        }

        private void HedefBildirim_Load(object sender, EventArgs e)
        {
            HedefListele();
        }

        private void HedefListele()
        {
            try
            {
                using (SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu))
                {
                    string query = @"
                        SELECT 
                            AsistanID,
                            NotificationDate AS 'Hedef Tarihi',
                            Message AS 'Hedef Açıklaması'
                        FROM 
                            HedefBildirimi";

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
