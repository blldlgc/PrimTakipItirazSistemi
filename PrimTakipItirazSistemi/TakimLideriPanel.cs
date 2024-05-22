﻿using System;
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
	public partial class TakimLideriPanel : Form
	{
		public TakimLideriPanel()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			UyeEkle frmEkle = new UyeEkle();
			frmEkle.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			UyeListele frmUyeListe = new UyeListele();
			frmUyeListe.Show();
		}

        private void Itırazlar_Click(object sender, EventArgs e)
        {
			TakimLideriItirazlari takimLideriItirazlari = new TakimLideriItirazlari();
			takimLideriItirazlari.Show();
        }
    }
}
