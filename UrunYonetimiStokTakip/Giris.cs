using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        KullaniciManager manager = new KullaniciManager();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve  Şifre boş geçilemez!");
            }
            else
            {
                var kullanini = manager.Find(k => k.KullaniciAdi == txtKullaniciAdi.Text && k.Sifre == txtSifre.Text && k.Aktif == true);
                if (kullanini != null)
                {
                    Menu menu = new Menu();
                    this.Hide();
                    menu.Show();
                }
                else
                    MessageBox.Show("Giriş Başarısız!");
            }           
        }
    }
}
