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
    public partial class formPenjualan: Form
    {
        public formPenjualan()
        {
            InitializeComponent();
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
                    SqlCommand cmd = new SqlCommand("select kd_produk, nama_produk, harga_jual from [Produk] where kd_produk = @kd_produk", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@kd_produk", textBox1.Text);
                    DataTable dt = new DataTable();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    if(dt.Rows.Count > 0)
                    {
                        string kd_produk = dt.Columns[0].ToString();
                        string nama_produk = dt.Columns[1].ToString();
                        int qty = 1;
                        int harga_jual = Convert.ToInt32(dt.Columns[2]);
                        int total = qty * harga_jual;


                        int sum = 0;
                        for(int i = 0; i < dt.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = Properti.conn())
            {
                string data = "1";
                SqlCommand cek = new SqlCommand("select top 1 no_penjualan from [Penjualan] order by no_penjualan desc", conn);
                int cekNo = (int)cek.ExecuteScalar();

                if(cekNo == null)
                {
                    SqlCommand tambahpertama = new SqlCommand("insert into [penjualan] values (@no_penjualan, @tanggal_jual, @kd_pelanggan, @total)", conn);
                    tambahpertama.CommandType = CommandType.Text;
                    tambahpertama.Parameters.AddWithValue("@kd_produk", data);
                    tambahpertama.Parameters.AddWithValue("@tanggal_jual", data);
                    tambahpertama.Parameters.AddWithValue("@kd_pelanggan", "1");

                }
            }
        }
    }
}
