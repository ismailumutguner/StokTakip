using BL;
using Entities;
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
    public partial class SiparisYonetimi : Form
    {
        public SiparisYonetimi()
        {
            InitializeComponent();
        }
        SiparisManager manager = new SiparisManager();
        MusteriManager musteri = new MusteriManager();
        UrunManager urun = new UrunManager();
        void Yukle()
        {
            dgvSiparisler.DataSource = manager.GetAll();
            cbMusteriler.DataSource = musteri.GetAll();
            cbMusteriler.DisplayMember = "Adi";
            cbMusteriler.ValueMember = "Id";
            cbUrunler.DataSource = urun.GetAll();
            cbUrunler.DisplayMember = "UrunAdi";
            cbUrunler.ValueMember = "Id";
            dgvSiparisler.Columns.Remove("Urun");
            dgvSiparisler.Columns.Remove("Musteri");
        }
        void Temizle()
        {
            txtSiparisNo.Text = String.Empty;
            lblId.Text = "0";
        }
        private void SiparisYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                    new Siparis
                    {
                        MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                        SiparisNo = txtSiparisNo.Text,
                        SiparisTarihi = dtpSiparisTarihi.Value,
                        UrunId = Convert.ToInt32(cbUrunler.SelectedValue)
                    }
                    );
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Kayıt eklenemedi !");
            }
        }       
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text != "0")
                {
                    var sonuc = manager.Update(
                   new Siparis
                   {
                       Id = Convert.ToInt32(lblId.Text),
                       MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                       SiparisNo = txtSiparisNo.Text,
                       SiparisTarihi = dtpSiparisTarihi.Value,
                       UrunId = Convert.ToInt32(cbUrunler.SelectedValue)
                   }
                   ) ;
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Kayıt Güncellendi!");
                    }
                }
                else
                {
                    MessageBox.Show("Listeden güncellenecek kaydı seçniz!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Kayıt güncellenemedi !");
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden silinecek kaydı seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Kayıt silinemedi !");
            }
        }
        private void dgvSiparisler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var siparis = manager.Get(Convert.ToInt32(dgvSiparisler.CurrentRow.Cells[0].Value));
                txtSiparisNo.Text = siparis.SiparisNo;
                cbMusteriler.SelectedValue = siparis.MusteriId;
                cbUrunler.SelectedValue = siparis.UrunId;
                dtpSiparisTarihi.Value = siparis.SiparisTarihi;
                lblId.Text = dgvSiparisler.CurrentRow.Cells[0].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Kayıt getirelemedi !");
            }
        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KategoriYonetimi kategorYonetimi = new KategoriYonetimi();
            this.Close();
            kategorYonetimi.ShowDialog();
        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkaYonetimi markaYonetimi = new MarkaYonetimi();
            this.Close();
            markaYonetimi.ShowDialog();
        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunYonetimi urunYonetimi = new UrunYonetimi();
            this.Close();
            urunYonetimi.ShowDialog();
        }

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            this.Close();
            kullaniciYonetimi.ShowDialog();
        }
        private void müşteriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriYonetimi musteriYonetimi = new MusteriYonetimi();
            this.Close();
            musteriYonetimi.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }    
}
