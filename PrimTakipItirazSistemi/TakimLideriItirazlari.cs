using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PrimTakipItirazSistemi
{
    public partial class TakimLideriItirazlari : Form
    {
        public TakimLideriItirazlari()
        {
            InitializeComponent();
        }

        private void TakimLideriItirazlari_Load(object sender, EventArgs e)
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
                            [Sicil No], [Ad Soyad], [ItirazID], [İtiraz Ayı], [İtiraz Durumu], [İtiraz Açıklaması], [Durum]
                        FROM vW_TLItirazListele
                        WHERE 
                            [TakımID] = @TakimLideriID 
                        ORDER BY [ItirazID] DESC, [Sicil No];";

                    SqlDataAdapter verileriListele = new SqlDataAdapter(query, baglantim);
                    verileriListele.SelectCommand.Parameters.AddWithValue("@TakimLideriID", Form1.GirisYapanLiderID);
                    DataSet ds = new DataSet();
                    verileriListele.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    // "İtiraz Cevapla" butonu eklemek için
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Durum"].Value != null && row.Cells["Durum"].Value.ToString() == "İtiraz Cevapla")
                        {
                            DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                            btnCell.Value = "İtiraz Cevapla";
                            row.Cells["Durum"] = btnCell;
                        }
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
                                row.Cells["İtiraz Durumu"].Style.BackColor = Color.Yellow;
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
            if (e.ColumnIndex == dataGridView1.Columns["Durum"].Index && dataGridView1.Rows[e.RowIndex].Cells["Durum"].Value.ToString() == "İtiraz Cevapla")
            {
                int itirazID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ItirazID"].Value);
                using (ItirazCevapla form = new ItirazCevapla(itirazID))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        ItirazlariGoster();
                    }
                }
            }
        }

        private void buttonCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
