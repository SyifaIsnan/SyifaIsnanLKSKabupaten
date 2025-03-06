using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class formHome: Form
    {
        public formHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formProduk fp = new formProduk();
            fp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formPenjualan pl = new formPenjualan();
            pl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formPembelian fb = new formPembelian();
            fb.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
