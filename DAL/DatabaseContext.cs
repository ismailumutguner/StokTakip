using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }  
        
        public virtual DbSet<Kategori> Kategoriler { get; set; } //veri taban�m�z� temsil eden yap�lar.
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Siparis> SiparisLer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();// Veri taban�nda olu�acak olan tablolar�n isimlerine s tak�s� germemesi i�in.
            base.OnModelCreating(modelBuilder);
        }
        //Migration : Veri taban� g�ncelleme
        // Migrationu package manager konsoldan yap�yoruz.
        // DAL i�ine yerle�tiriliyor yazmam�z gereken kod ise "enable-migrations" dur. De�i�iklikleri "update-database" kodu ile g�ncelliyoruz.
        //
        public class DatabaseInitializer :CreateDatabaseIfNotExists<DatabaseContext> 
            //DropCreateDatabaseIfModelChanges<DatabaseContext>  Model de�i�ti�nde veri taban�n� silip yenisine g�re d�zenliyor.
            //CreateDatabaseIfNotExists<DatabaseContext> CreateDatabaseIfNotExists e�er veri taban� yoksa olu�tur DatabaseContext i�erisindeki dbsetlere g�re
        {
            protected override void Seed(DatabaseContext context) // Seed metodu veri taban� olu�turulduktan sonra devreye girip i�lem yapmam�z� sa�lar
            {
                if (!context.Kullanicilar.Any())
                {
                    context.Kullanicilar.Add(
                        new Kullanici()
                        {
                            Aktif = true,
                            KullaniciAdi = "Admin",
                            Sifre = "123456"
                        }
                        );
                    context.SaveChanges();
                }
                base.Seed(context);
            }
        }
    }
}
/*
Migration i�lemleri ile veri taban�n� silmeden tablolar� g�ncelleyebilir veye tabloda classlarda yapt���m�z de�i�ikleri kullanarak g�ncelleme yapabiliyoruz.
Migrationu aktif etmek i�in yap�lacaklar
1- �ncelikle PMC (Package manager console) kapal� ise onu Visual Studionun �st men�s�nde view > other windows > package manager console yolunu kullanarak aktif 
ediyoruz. PMC ile komut kullanarak paket y�kleme (Entity freamwork vb), migration i�lemler vb yapabilmek i�in.
2- PMC ekran�nda komut �al��t�raca��m�z projeyi (DAL Katman�) Default project alan�ndan se�iyoruz. EF nin bu katmanda y�kl� olmas� gerekir!
3- Komut sat�rlar�nda enable - migrations komutu yaz�p enter ile �al��t�rd�k ve DAL katamn�nda Migrations klas�r� ve i�indeki classlar olu�mas� laz�m i�lem ba�ar�l� ise ,
i�lem ba�ar�s�z ise EF s�r�m�n� son son s�r�me almay� dene, yine olmaz ise s�r�m d���rerek dee, katmanlardai EF s�r�mlerinin ayn� s�rm oldu�undan emin ol
4- Olu�an Migrations � veri taban�na uygulamak i�in PMC ye update-database yaz�p enter a basmam�z gerek.
5- Daha sonra model class lar�m�zda yapaca��m�z ge�i�iklik sonras� veri taban�n� g�ncellemek i�in Add-Migration Migrationismi �eklinde Migrationa bir isim vererek enter diyoruz
6- Ekledi�imiz Migration � i�lemek i�in yine update-database komutunu �al��t�r�yoruz
 */