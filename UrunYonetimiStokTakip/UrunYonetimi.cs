using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        UrunManager manager = new UrunManager();
        KategoriManager kategoriManager = new KategoriManager();
        MarkaManager markaManager = new MarkaManager();
        void Yukle()
        {
            dgvUrunler.DataSource = manager.GetAll();
            cbUrunKategorisi.DataSource = kategoriManager.GetAll();/*kategoriManager üzerindeki getall metoduyla 
            veritabanındaki tüm kategorileri çekip cburunkategorisi ne verileri yükledik. Sonrasında design tarafından
            display member alanında veritabanındaki kategori tablosundan gelen veriler üzerinden KategoriAdi sütununu 
            program kullanıcısının göreceği listede gösterdik. Ürün eklerken ise kategoriId sütununa seçilen 
            kategorinin Id değerini atayabilmek için yine design tarafında cbUrunKategorisi ne sağ tık properties 
            yapıp Value Member alanına Id yazıp enter a bastık ki arkayüzde seçilen kategorinin ıd sini yakalayıp 
            Urun tablosundaki KategoriId sütununa yollayabilelim..*/
            cbUrunMarkasi.DataSource = markaManager.GetAll();/*Markaları çekip cbUrunMarkasi na yükledik, ön yüzden
            Display Member a MarkaAdi, Value Member a Id yazıp enter dedik.*/
        }
        void Temizle() 
        {
            txtIskonto.Text = String.Empty;
            txtKdv.Text = String.Empty;
            txtStokMiktari.Text = String.Empty;
            txtUrunAdi.Text = String.Empty;
            txtUrunFiyati.Text = String.Empty;
            cbDurum.Checked = false;    
            rtbUrunAciklamasi.Text = String.Empty;
            lblId.Text = "0";
            lblEkenmeTarihi.Text = String.Empty;
        }
        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }       
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrunFiyati.Text)) /* Veri tabanında not null olarak işaretli tüm sütunlar 
            için bu şekilde boş geçilmez kontrolü yaptırmak gerekir.*/
            {              
                try
                {
                    var sonuc = manager.Add(
                        new Urun
                        {
                            UrunAdi = txtUrunAdi.Text,
                            UrunFiyati = decimal.Parse(txtUrunFiyati.Text),
                            Aciklama = rtbUrunAciklamasi.Text,
                            Aktif = cbDurum.Checked,
                            EklenmeTarihi = DateTime.Now,
                            Iskonto = int.Parse(txtIskonto.Text),
                            Kdv = int.Parse(txtKdv.Text),
                            StokMiktari = int.Parse(txtStokMiktari.Text),
                            ToptanFiyat = decimal.Parse(txtUrunFiyati.Text),
                            KategoriId = int.Parse(cbUrunKategorisi.SelectedValue.ToString()),
                            MarkaId = int.Parse(cbUrunMarkasi.SelectedValue.ToString())/*obje geldiği için ilk olarak 
                            stringe çevirip sonra int e çeviriyoruz*/
                        }
                        );
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Eklendi!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata oluştu! Kayıt Eklenemedi! Lütefn tüm alanları doldurup tekrar deneyiniz");
                }                
            }
            else 
                MessageBox.Show("Ürün Fiyatı boş geçilemez!");
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrunFiyati.Text)) /* Veri tabanında not null olarak işaretli tüm
            sütunlar için bu şekilde boş geçilmez kontrolü yaptırmak gerekir.*/
            {
                try
                {
                    int urunId = Convert.ToInt32(lblId.Text);
                    if (urunId > 0)
                    {
                        var sonuc = manager.Update(
                        new Urun
                        {
                            Id = urunId,
                            UrunAdi = txtUrunAdi.Text,
                            UrunFiyati = decimal.Parse(txtUrunFiyati.Text),
                            Aciklama = rtbUrunAciklamasi.Text,
                            Aktif = cbDurum.Checked,
                            EklenmeTarihi = DateTime.Now,
                            Iskonto = int.Parse(txtIskonto.Text),
                            Kdv = int.Parse(txtKdv.Text),
                            StokMiktari = int.Parse(txtStokMiktari.Text),
                            ToptanFiyat = decimal.Parse(txtUrunFiyati.Text),
                            KategoriId = int.Parse(cbUrunKategorisi.SelectedValue.ToString()),
                            MarkaId = int.Parse(cbUrunMarkasi.SelectedValue.ToString())/*obje geldiği için ilk
                            olarak stringe çevirip sonra int e çeviriyoruz*/
                        }
                        );
                        if (sonuc > 0)
                        {
                            Temizle();
                            Yukle();
                            MessageBox.Show("Kayıt Güncellendi!");
                        }
                    }
                    else
                        MessageBox.Show("Listeden bir ürün seçiniz!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata oluştu! Kayıt Güncellenemedi! Lütefn tüm alanları doldurup tekrar deneyiniz");
                }
            }
            else
                MessageBox.Show("Ürün Fiyatı boş geçilemez!");
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
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Silinemedi!");
            }
        }
        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvUrunler.CurrentRow.Cells[0].Value.ToString();
                int urunId = Convert.ToInt32(lblId.Text);
                if (urunId > 0)
                {
                    var urun = manager.Get(urunId);
                    if (urun != null)
                    {
                        txtIskonto.Text = urun.Iskonto.ToString();
                        txtKdv.Text = urun.Kdv.ToString();
                        txtStokMiktari.Text = urun.StokMiktari.ToString();
                        txtUrunAdi.Text = urun.UrunAdi;
                        txtUrunFiyati.Text = urun.UrunFiyati.ToString();
                        rtbUrunAciklamasi.Text = urun.Aciklama;
                        cbDurum.Checked = urun.Aktif;
                        lblEkenmeTarihi.Text = urun.EklenmeTarihi.ToString();
                        cbUrunKategorisi.SelectedValue = urun.KategoriId;
                        cbUrunMarkasi.SelectedValue = urun.MarkaId;
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Atanırken Hata Oluştu!");
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

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            this.Close();
            kullaniciYonetimi.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void müşteriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriYonetimi musteriYonetimi = new MusteriYonetimi();
            this.Close();
            musteriYonetimi.ShowDialog();
        }

        private void siparişYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiparisYonetimi siparisYonetimi = new SiparisYonetimi();
            this.Close();
            siparisYonetimi.ShowDialog();
        }
    }
}
