using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    interface IRepository <T> // IRepository interface i Repository class ımızın içinde olması gereken metotları tanımlayacak.
    {
        List<T> GetAll (); // Bu metot içerisinde T parametresine yerleştirilecek class ın tüm verilerini listeleyecek.
        List<T> GetAll (Expression<Func<T, bool>> expression); // where ile filtrelenebilen kayıtları getirir.
        T Get (int id); // T kısmına gönderilecek class için(urun.cs, kategori.cs vb.) aldığı id ye ait kaydı veri tabanından getirecek.
        T Find (Expression<Func<T, bool>> expression); /* T kısmına gönderilecek class için bir expression yani linq filitreleme sorgusu alıp
        bir yada daha fazla alanla filitrelenen kaydı getirir(x=>x.Id == 1) gibi */ 
        int Add(T entity);// Ekleme metodu.
        int Update(T entity);// Güncelleme metodu.
        int Delete(int id);// Silme metodu.
    }
}