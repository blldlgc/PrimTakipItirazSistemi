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
                using (SqlConnection baglantim = new SqlConnection("Data Source=MONSTER\\SQLEXPRESS; Initial Catalog=PrimTakipItirazSistemi; Integrated Security=True; TrustServerCertificate=True"))
                {
                    string query = @"
                        SELECT 
                            a.SicilNo AS [Sicil No],
                            a.Asistan_Ad + ' ' + a.Asistan_Soyad AS [Ad Soyad],
                            i.ItirazAciklamasi AS [İtiraz Açıklaması],
                            p.Ay AS [İtiraz Ayı],
                            i.ItirazID,
                            d.DurumAdi AS [İtiraz Durumu],
                            CASE 
                                WHEN i.ItirazCevabi IS NULL THEN 'İtiraz Cevapla' 
                            ELSE 'Cevaplandı' 
                            END AS [Durum]
                        FROM 
                            Itirazlar i
                        JOIN 
                            Asistanlar a ON i.AsistanID = a.AsistanID
                        JOIN
                            Primler p ON i.PrimID = p.PrimID
                        JOIN 
                            TakimLiderleri tl ON a.TakimID = tl.TakimID 
                        JOIN
                            ItirazDurumlari d ON i.ItirazDurumuID = d.ItirazDurumuId
                        WHERE 
                            tl.TakimID = @TakimLideriID -- TakimID ile filtreleme
                        ORDER BY [İtiraz Ayı], [Sicil No];";

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
