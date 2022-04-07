using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Nefes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SQLiteConnection connection = new SQLiteConnection(@"Data Source=C:\Sqlite\sqlite.db;Version=3;Read Only=False;");
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            connection.Open();
            string sql = "select PerAd,PerSoyad,DepAd from Departman_tbl inner join Personel_tbl on Departman_tbl.DepID=Personel_tbl.DepartmanId";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql,connection);
            adapter.Fill(dt);
           dataGridView1.DataSource = dt;
            connection.Close();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    dataGridView1.Rows[0].Cells[1].Value = dr[1].ToString();
            //}
            DataTable dt2 = new DataTable();
            connection.Open();
            string sorgu3 = " Select UrunAd,PerAd,DepAd from Urun_Tbl inner join Departman_tbl ON Departman_tbl.DepID=Urun_Tbl.Departman" +
                " inner join Personel_tbl on Personel_tbl.PerId=Urun_Tbl.Personel "; 
                //"SELECT PerAd,PerSoyad,DepartmanAd FROM Personel_tbl INNER JOIN Urun_Tbl ON Personel_tbl.PerID = Urun_Tbl.Personel inner join Departman_tbl on  Departman_tbl.DepID=Personel_tbl.DepartmanId";
            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(sorgu3, connection);
            adapter2.Fill(dt2);
            dataGridView3.DataSource = dt2;
            connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sorgu = "insert into Personel_tbl(PerAd,PerSoyad,DepartmanId) values(@p1,@p2,@p3)";
            SQLiteCommand ekle= new SQLiteCommand(sorgu,connection);
            ekle.Parameters.AddWithValue("@p1", textBox1.Text);
            ekle.Parameters.AddWithValue("@p2", textBox2.Text);
            ekle.Parameters.AddWithValue("@p3", textBox3.Text);
            ekle.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Personel Eklendi");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sorgu2 = "delete from Personel_tbl where  PerAd=@p1";
            SQLiteCommand sil= new SQLiteCommand(sorgu2 ,connection);
            sil.Parameters.AddWithValue("@p1", textBox1.Text);
            sil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Personel Silindi.");

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sorgu = "insert into Urun_Tbl(UrunAd,Personel,Departman) values(@p1,@p2,@p3)";
            SQLiteCommand ekle = new SQLiteCommand(sorgu, connection);
            ekle.Parameters.AddWithValue("@p1", textBox6.Text);
            ekle.Parameters.AddWithValue("@p2", textBox5.Text);
            ekle.Parameters.AddWithValue("@p3", textBox4.Text);
            ekle.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Satış Eklendi");


            


        }


    }
}
