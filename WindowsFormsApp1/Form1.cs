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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "admin";

            if (Properti.validasi(this.Controls))
            {
                MessageBox.Show("Data yang ingin diinput tidak boleh kosong!");
            }
            else if (textBox1.Text == username && textBox2.Text == password)
            {
                this.Hide();
                formHome fh = new formHome();
                fh.Show();
            }
            else if (textBox1.Text != username && textBox2.Text != password)
            {
                MessageBox.Show("Username atau password yang anda masukkan salah!");
            }
        }
    }
}
