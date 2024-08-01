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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KO6819R\SQLEXPRESS;Initial Catalog=proje;Integrated Security=True");


        private void BtnGirisYap_MouseHover(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.LightYellow;
        }

        private void BtnGirisYap_MouseLeave(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.AliceBlue;
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_ADMIN where KullaniciAd= @p1 and Sifre=@p2", baglanti());
            komut.Parameters.AddWithValue("@p1", TextKullaniciAd.Text);

        }

    /*    private SqlConnection baglanti()
        {
            throw new NotImplementedException();
        } */
    }
}
