using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BetaMartLauraSharon
{
    public partial class Form1 : Form
    {
        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Asus\Documents\BetaMartshr.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Insert into databarang_shr (Nama, Kode_Barang, Harga_Barang, Stok_Barang) values ('" + Nama.Text + "', '" + KodeBarang.Text + "', '" + HargaBarang.Text + "', '" + StokBarang.Text + "')";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Anda Berhasil Disimpan");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = koneksi.CreateCommand();
            string query = "update databarang_shr set Nama='" + Nama.Text + "' ,Stok_Barang='" + StokBarang.Text + "' ,Harga_barang='" + HargaBarang.Text + "' ,Kode_Barang='" + KodeBarang.Text + "' where ID=" + Id.Text + "";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            Id.Text = "";
            Nama.Text = "";
            StokBarang.Text = "";
            HargaBarang.Text = "";
            KodeBarang.Text = "";
            MessageBox.Show("Barang Anda Berhasil Diedit");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = koneksi.CreateCommand();
            string query = "delete from databarang_shr where ID=" + Id.Text + "";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            koneksi.Close();
            Id.Text = "";
            MessageBox.Show("Data Barang Telah Dihapus");
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "select * from databarang_shr where Nama='" + Search.Text + "'or Kode_Barang='" + Search.Text + "'or Harga_Barang='" + Search.Text + "'or Stok_Barang='" + Search.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(perintah, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        void ShowData()
        {
            koneksi.Open();
            string query = "select * from databarang_shr";
            OleDbDataAdapter da = new OleDbDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}