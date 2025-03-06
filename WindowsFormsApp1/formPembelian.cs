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

namespace WindowsFormsApp1
{
    public partial class formPembelian: Form
    {
        public formPembelian()
        {
            InitializeComponent();


            dataGridView1.Columns.Add("kd_produk", "KODE PRODUK");
            dataGridView1.Columns.Add("nama_produk", "NAMA PRODUK");
            dataGridView1.Columns.Add("kategori", "KATEGORI");
            dataGridView1.Columns.Add("satuan", "SATUAN");
            dataGridView1.Columns.Add("harga_modal", "KODE PRODUK");
            dataGridView1.Columns.Add("harga_jual", "KODE PRODUK");
            dataGridView1.Columns.Add("stok", "KODE PRODUK");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var conn = Properti.conn())
            {
                string data = "1";
                SqlCommand cek = new SqlCommand("select top 1 no_penjualan from [Penjualan] order by no_penjualan desc", conn);
                int cekNo = (int)cek.ExecuteScalar();

                if (cekNo == null)
                {
                    SqlCommand tambahpertama = new SqlCommand("insert into [penjualan] values (@)");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(textBox2.Text);
            int bayar = Convert.ToInt32(textBox3.Text);

            if (bayar < total)
            {
                MessageBox.Show("Maaf, uang anda kurang!");
            }
            else
            {
                int kembali = bayar - total;
                textBox4.Text = kembali.ToString();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            using (var conn = Properti.conn())
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SqlCommand cmd = new SqlCommand("select kd_produk, nama_produk, harga_beli from [Produk] where kd_produk = @kd_produk", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@kd_produk", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    if (dt.Rows.Count > 0)
                    {
                        string kd_produk = dt.Columns[0].ToString();
                        string nama_produk = dt.Columns[1].ToString();
                        int qty = 1;
                        int harga_beli = Convert.ToInt32(dt.Columns[2].ToString());
                        int total = qty * harga_beli;

                        int sum = 0;
                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            sum += dataGridView1.Rows.Count;
                        }

                        dataGridView1.Rows.Add(kd_produk, nama_produk, qty, sum);

                    }
                    else

                    {
                        MessageBox.Show("Data yang anda cari tidak ditemukan!");
                    }
                }
            }
        }
    }
}

