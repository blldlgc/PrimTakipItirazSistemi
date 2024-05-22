using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace PrimTakipItirazSistemi
{
    public partial class AsistanPrimListesi : Form
    {
        public AsistanPrimListesi()
        {
            InitializeComponent();
        }

        private void AsistanPrimListesi_Load(object sender, EventArgs e)
        {
            PrimleriGoster();
        }

        private void PrimleriGoster()
        {
            try
            {
                using (SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu))
                {
                    string query = "SELECT AsistanID AS [Asistan ID], Ay AS [Ay],PrimID AS [Prim ID] ,PrimMiktari AS [Prim Miktarı], PrimAciklamasi AS [Prim Açıklaması] FROM Primler WHERE AsistanID = @AsistanID ORDER BY PrimID DESC";
                    SqlDataAdapter verileriListele = new SqlDataAdapter(query, baglantim);
                    int asistanID = Form1.GirisYapanAsistanID;
                    verileriListele.SelectCommand.Parameters.AddWithValue("@AsistanID", asistanID);
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
            
        }

        private void ButtonCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void primItıraz_click(object sender, EventArgs e)
        {
            int sonPrimID = Convert.ToInt32(dataGridView1.Rows[0].Cells["Prim ID"].Value);

            PrimItıraz primItıraz = new PrimItıraz(sonPrimID);
            primItıraz.Show();
        }
    }
}

