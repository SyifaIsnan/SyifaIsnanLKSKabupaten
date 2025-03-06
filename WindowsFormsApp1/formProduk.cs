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
    public partial class formProduk: Form
    {
        public formProduk()
        {
            InitializeComponent();
            tampildata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = Properti.conn())
            {
                if (Properti.validasi(this.Controls))
                {
                    MessageBox.Show("Mohon isi semua data sesuai ketentuan!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into [Produk] values (@kd_produk, @nama_produk, @kd_kategori, @satuan, @harga_modal, @harga_jual, @stok)", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@kd_produk", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nama_produk", textBox2.Text);
                    cmd.Parameters.AddWithValue("@kd_kategori", textBox3.Text);
                    cmd.Parameters.AddWithValue("@satuan", textBox4.Text);
                    cmd.Parameters.AddWithValue("@harga_modal", textBox5.Text);
                    cmd.Parameters.AddWithValue("@harga_jual", textBox6.Text);
                    cmd.Parameters.AddWithValue("@stok", textBox7.Text);
                    cmd.ExecuteNonQuery();
                    tampildata();

                }
            }
        }

        private void tampildata()
        {
            using (var conn = Properti.conn())
            {
                SqlCommand cmd = new SqlCommand("select * from [Produk]", conn);
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var conn = Properti.conn())
            {
                if (Properti.validasi(this.Controls))
                {
                    MessageBox.Show("Mohon isi semua data sesuai ketentuan!");
                }
                else
                {
                    
                    SqlCommand cmd = new SqlCommand("update [Produk] set kd_produk = @kd_produk, nama_produk = @nama_produk, kd_kategori =  @kd_kategori, satuan = @satuan, harga_modal = @harga_modal, harga_jual = @harga_jual, stok = @stok where kd_produk = @kd_produk", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@kd_produk", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nama_produk", textBox2.Text);
                    cmd.Parameters.AddWithValue("@kd_kategori", textBox3.Text);
                    cmd.Parameters.AddWithValue("@satuan", textBox4.Text);
                    cmd.Parameters.AddWithValue("@harga_modal", textBox5.Text);
                    cmd.Parameters.AddWithValue("@harga_jual", textBox6.Text);
                    cmd.Parameters.AddWithValue("@stok", textBox7.Text);
                    cmd.ExecuteNonQuery();
                    tampildata();

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow.Cells;
            textBox1.Text = row["kd_produk"].Value.ToString();
            textBox2.Text = row["nama_produk"].Value.ToString();
            textBox3.Text = row["kd_kategori"].Value.ToString();
            textBox4.Text = row["satuan"].Value.ToString();
            textBox5.Text = row["harga_modal"].Value.ToString();
            textBox6.Text = row["harga_jual"].Value.ToString();
            textBox7.Text = row["stok"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var conn = Properti.conn())
            {
                if (Properti.validasi(this.Controls))
                {
                    MessageBox.Show("Mohon isi semua data sesuai ketentuan!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("delete from [Produk] where kd_produk = @kd_produk", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@kd_produk", textBox1.Text);
                    
                    cmd.ExecuteNonQuery();
                    tampildata();

                }
            }
        }
    }
}
