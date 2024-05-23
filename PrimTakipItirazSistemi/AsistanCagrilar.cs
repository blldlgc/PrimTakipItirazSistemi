using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimTakipItirazSistemi
{
	public partial class AsistanCagrilar : Form
	{
		public AsistanCagrilar()
		{
			InitializeComponent();
            Ara_Click(null, null);
		}

		private void AsistanCagrilar_Load(object sender, EventArgs e)
		{

		}


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void ButtonCikis_Click(object sender, EventArgs e)
        {
            this.Hide();
            AsistanMenu asistanMenu = new AsistanMenu();
            asistanMenu.Show();
        }

        private void Ara_Click(object sender, EventArgs e)
        {
            try
            {
                string aramaMetni = textBox1.Text;
                string query = "SELECT [Müşteri Adı], [Müşteri Soyadı], [Görüşme Tarihi], [Başlangıç Saati], [Bitiş Saati], [Görüşme Konusu], [Görüşme Durumu], [Çağrı ID] " +
               "FROM vw_CagriAra " +
               "WHERE [Müşteri Adı] LIKE @aramaMetni OR [Çağrı ID] = @cagriID " +
               "ORDER BY [Çağrı ID] DESC";

                using (SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu))
                {
                    SqlDataAdapter veriListele = new SqlDataAdapter(query, baglantim);
                    veriListele.SelectCommand.Parameters.AddWithValue("@aramaMetni", "%" + aramaMetni + "%");

                    int cagriID;
                    if (int.TryParse(aramaMetni, out cagriID))
                    {
                        veriListele.SelectCommand.Parameters.AddWithValue("@cagriID", cagriID);
                    }
                    else
                    {
                        veriListele.SelectCommand.Parameters.AddWithValue("@cagriID", DBNull.Value);
                    }

                    DataSet ds = new DataSet();
                    veriListele.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("Çağrı bulunamadı", "Prim Takip İtiraz Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null; // DataGridView'i temizler
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

        }

        private void cagriEkle_Click(object sender, EventArgs e)
        {
            this.Hide();
            CagriEkle cagriEkle = new CagriEkle();
            cagriEkle.Show();
        }
    }
}
