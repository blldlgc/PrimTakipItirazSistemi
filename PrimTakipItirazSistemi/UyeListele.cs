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
	public partial class UyeListele : Form
	{
		public UyeListele()
		{
			InitializeComponent();
		}
		SqlConnection baglantim = new SqlConnection(Form1.baglantiKodu);
		DataSet dataset = new DataSet();//üyeleri tut

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		UyeEkle frmuye = new UyeEkle();
		private void UyeListele_Load(object sender, EventArgs e)
		{
			
			frmuye.kullanicilari_goster();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable tablo = new DataTable();
			baglantim.Open();
			SqlDataAdapter adtr = new SqlDataAdapter("select * from kullanicilar where TCNo  like '" + textBox1.Text + "%' or kullaniciAdi like '" + textBox1.Text + "%'", baglantim);
			adtr.Fill(tablo);
			dataGridView1.DataSource = tablo;
			baglantim.Close();
		}
	}
}
