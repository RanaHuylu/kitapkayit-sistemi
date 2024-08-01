using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KO6819R\SQLEXPRESS;Initial Catalog=proje;Integrated Security=True");
        
            void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter(" Select * From TBLKITAPLAR", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        
        
        }    
        
        void sayac()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLSAYAC", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                LblKitap.Text = dr[0].ToString();
            }
            baglanti.Close();
        }
            
            
            private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            sayac();
        }

        private void TxtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLKITAPLAR " +
                "(ad, yazar, sayfa, yayınevı, tur)values(@p1, @p2, @p3, @p4, @p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYazar.Text);
            komut.Parameters.AddWithValue("@p3", TxtSayfa.Text);
            komut.Parameters.AddWithValue("@p4", TxtYayınevi.Text);
            komut.Parameters.AddWithValue("@p5", TxtTür.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            listele();
            sayac();
        }

        private void LblKitap_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtYazar.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSayfa.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtYayınevi.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtTür.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from tblkıtaplar where Id=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Sistemden Silindi");
            listele();
            sayac();
        }
    }
}
