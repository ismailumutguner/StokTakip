using System;
using BL;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UrunYonetimiStokTakip.WebFormUI
{
    public partial class KategoriYonetimi : System.Web.UI.Page
    {
        KategoriManager manager = new KategoriManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvKategoriler.DataSource = manager.GetAll();
            dgvKategoriler.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                new Kategori
                {
                    KategoriAdi = txtKategoriAdi.Text,
                    Aciklamasi = txtKategoriAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = DateTime.Now
                }
                );
                if (sonuc > 0)
                {
                    Response.Redirect("KategoriYonetimi.aspx");// Sayfamız tekradan yenilemiş oluyoruz.
                    //Yukle();

                }
                else
                    lblMesaj.Text = "Kayıt Eklenemedi!";
            }
            catch (Exception hata) // Buradaki hata nesnesininden hata deylarına ulaşabiliriz.
            {
                lblMesaj.Text = "Hata Oluştu! Kayıt Eklenemedi!";
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblId.Text);
                if (id > 0)
                {
                    var sonuc = manager.Update(
                    new Kategori
                    {
                        Id = int.Parse(lblId.Text),
                        KategoriAdi = txtKategoriAdi.Text,
                        Aciklamasi = txtKategoriAciklamasi.Text,
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = Convert.ToDateTime(lblEklenmeTarihi.Text)
                    }
                    );
                    if (sonuc > 0)
                    {
                        Response.Redirect("KategoriYonetimi.aspx");
                    }
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(),"Uyarı",$"<script>alert('Lütfen " +
                        $"Güncellenecek Kaydı Seçiniz!')</script>");
            }
            catch (Exception hata) // Buradaki hata nesnesininden hata deylarına ulaşabiliriz.
            {
                lblMesaj.Text = "Hata Oluştu! Kayıt Eklenemedi!";
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox("Listeden silinecek kaydı seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc > 0)
                    {
                        Response.Redirect("KategoriYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Silinemedi!");
            }
        }
        protected void dgvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvKategoriler.SelectedRow;
                var kategori = manager.Get(Convert.ToInt32(row.Cells[1].Text));
                txtKategoriAdi.Text = kategori.KategoriAdi;
                txtKategoriAciklamasi.Text = kategori.Aciklamasi;
                cbDurum.Checked = kategori.Aktif;
                lblEklenmeTarihi.Text = kategori.EklenmeTarihi.ToString();
                lblId.Text = kategori.Id.ToString();
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu!");
            }
        }
        void MessageBox(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }
    }
}