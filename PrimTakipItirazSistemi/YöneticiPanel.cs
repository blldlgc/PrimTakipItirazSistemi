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
	public partial class YöneticiPanel : Form
	{
		public YöneticiPanel()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			UyeEkle uyeEkle = new UyeEkle();
			uyeEkle.Show();
		}

        private void PrimHesapat_Click(object sender, EventArgs e)
        {

			PrimHesaplat primHesaplat = new PrimHesaplat();
			primHesaplat.Show();

        }
    }
}
