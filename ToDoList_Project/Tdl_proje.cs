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
using System.Data.SqlClient;

namespace ToDoList_Project
{
    public partial class Tdl_proje : Form
    {
        public Tdl_proje()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void Tdl_proje_Load(object sender, EventArgs e)
        {
            //veri tabanındaki tabloyu dataGridView1-2 ye çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_ToDoList where GorevDurum=0 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dr = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter("Select * From Tbl_ToDoList where GorevDurum=1", bgl.baglanti());
            db.Fill(dr);
            dataGridView2.DataSource = dr;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*dataGridView1deki tablo üzerindeki herhangi veri üzerine tek tıklamada
            seçilen satırı görev groupbox'ına ekleme.*/
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBaslık.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            rchAciklama.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*dataGridView2deki tablo üzerindeki herhangi veri üzerine tek tıklamada
            seçilen satırı görev groupbox'ına ekleme.*/
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            txtBaslık.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            rchAciklama.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Tablomuza (Veri Tabanına) veri ekleme.
            SqlCommand komut = new SqlCommand("insert into Tbl_ToDoList (GorevAd,GorevAciklama) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBaslık.Text);
            komut.Parameters.AddWithValue("@p2", rchAciklama.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Görev Eklendi.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Tablodan (Veri Tabanından) Veri Silme
            SqlCommand komut = new SqlCommand("Delete from Tbl_ToDoList where GorevAd=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBaslık.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Görev Silindi", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnTamamlandı_Click(object sender, EventArgs e)
        {
            //Eklediğimiz görevi tamamlama.
            SqlCommand komut = new SqlCommand("update Tbl_ToDoList set GorevDurum=1,GorevAd=@p1,GorevAciklama=@p2 where Gorevid=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBaslık.Text);
            komut.Parameters.AddWithValue("@p2", rchAciklama.Text);
            komut.Parameters.AddWithValue("@p3", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Tebrikler", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //temizle butaonuna basınca Başlık ve Açıklama bölmesini temizleme imleci başlık bölgesine getirme
            txtid.Text = "";
            txtBaslık.Text = "";
            rchAciklama.Text = "";
            txtBaslık.Focus();
        }


    }
}
