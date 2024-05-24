using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimTakipItirazSistemi
{
	public partial class AsistanMenu : Form
	{
		public AsistanMenu()
		{
			InitializeComponent();
		}

		private void AsistanPanel_Click(object sender, EventArgs e)
		{		
			AsistanPanel asistanPanel = new AsistanPanel();
			asistanPanel.Show();
            this.Hide();
        }

		private void AsistanCagrilar_Click(object sender, EventArgs e)
		{			
			AsistanCagrilar asistanCagrilar = new AsistanCagrilar();
			asistanCagrilar.Show();
            this.Hide();
        }

		private void AsistanMenu_Load(object sender, EventArgs e)
		{

		}

        private void CagriEkle_Click(object sender, EventArgs e)
        {           
            CagriEkle cagriEkle = new CagriEkle();
            cagriEkle.Show();
            this.Hide();
        }

        private void PrimListesi_click(object sender, EventArgs e)
        {           
            AsistanPrimListesi primListesi = new AsistanPrimListesi();
            primListesi.Show();
            this.Hide();
        }

        private void Itırazlarım_Click(object sender, EventArgs e)
        {
			
			AsistanItirazlari asistanItirazlari = new AsistanItirazlari();
			asistanItirazlari.Show(); 
            this.Hide();
        }

        private void cikisBtn_click(object sender, EventArgs e)
        {
            this.Hide();
			Form1 form1 = new Form1();
			form1.Show();
        }

        private void Hedef_Click(object sender, EventArgs e)
        {
			HedefBildirim hedefBildirim = new HedefBildirim();
			hedefBildirim.Show();
        }
    }
}
