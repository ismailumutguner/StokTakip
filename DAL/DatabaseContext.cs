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
        
        public virtual DbSet<Kategori> Kategoriler { get; set; } //veri tabanýmýzý temsil eden yapýlar.
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Siparis> SiparisLer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();// Veri tabanýnda oluþacak olan tablolarýn isimlerine s takýsý germemesi için.
            base.OnModelCreating(modelBuilder);
        }
        //Migration : Veri tabaný güncelleme
        // Migrationu package manager konsoldan yapýyoruz.
        // DAL içine yerleþtiriliyor yazmamýz gereken kod ise "enable-migrations" dur. Deðiþiklikleri "update-database" kodu ile güncelliyoruz.
        //
        public class DatabaseInitializer :CreateDatabaseIfNotExists<DatabaseContext> 
            //DropCreateDatabaseIfModelChanges<DatabaseContext>  Model deðiþtiðnde veri tabanýný silip yenisine göre düzenliyor.
            //CreateDatabaseIfNotExists<DatabaseContext> CreateDatabaseIfNotExists eðer veri tabaný yoksa oluþtur DatabaseContext içerisindeki dbsetlere göre
        {
            protected override void Seed(DatabaseContext context) // Seed metodu veri tabaný oluþturulduktan sonra devreye girip iþlem yapmamýzý saðlar
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
Migration iþlemleri ile veri tabanýný silmeden tablolarý güncelleyebilir veye tabloda classlarda yaptýðýmýz deðiþikleri kullanarak güncelleme yapabiliyoruz.
Migrationu aktif etmek için yapýlacaklar
1- Öncelikle PMC (Package manager console) kapalý ise onu Visual Studionun üst menüsünde view > other windows > package manager console yolunu kullanarak aktif 
ediyoruz. PMC ile komut kullanarak paket yükleme (Entity freamwork vb), migration iþlemler vb yapabilmek için.
2- PMC ekranýnda komut çalýþtýracaðýmýz projeyi (DAL Katmaný) Default project alanýndan seçiyoruz. EF nin bu katmanda yüklü olmasý gerekir!
3- Komut satýrlarýnda enable - migrations komutu yazýp enter ile çalýþtýrdýk ve DAL katamnýnda Migrations klasörü ve içindeki classlar oluþmasý lazým iþlem baþarýlý ise ,
iþlem baþarýsýz ise EF sürümünü son son sürüme almayý dene, yine olmaz ise sürüm düþürerek dee, katmanlardai EF sürümlerinin ayný sürm olduðundan emin ol
4- Oluþan Migrations ý veri tabanýna uygulamak için PMC ye update-database yazýp enter a basmamýz gerek.
5- Daha sonra model class larýmýzda yapacaðýmýz geðiþiklik sonrasý veri tabanýný güncellemek için Add-Migration Migrationismi þeklinde Migrationa bir isim vererek enter diyoruz
6- Eklediðimiz Migration ý iþlemek için yine update-database komutunu çalýþtýrýyoruz
 */