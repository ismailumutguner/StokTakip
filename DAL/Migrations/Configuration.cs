using Entities;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Migrations
{ 
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // Veri tabanı değişikliklerini otomatik olarak uygular
            AutomaticMigrationDataLossAllowed = true;// olası veri kayıplarını kabul ediyorum
            //ContextKey = "DAL.DatabaseContext";
        }

        protected override void Seed(DAL.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (!context.Kullanicilar.Any())
            {
                context.Kullanicilar.Add(
                    new Kullanici()
                    {
                        Aktif = true,
                        KullaniciAdi = "Admin",
                        Sifre = "123456",
                        Adi ="Admin",
                        Email ="admin@urunyonetimstoktakip.com",
                        Soyadi ="ADMIN",
                    }
                    );
                context.SaveChanges();
            }
            base.Seed(context);
        }
    }
}