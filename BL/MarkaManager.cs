using DAL;
using Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BL
{
    public class MarkaManager
    {
        DatabaseContext context = new DatabaseContext();
        public List<Marka> GetAll() // veri tabanındaki tüm markaları döndüren metot
        {
            return context.Markalar.ToList();
        }
        public Marka Get(int id) // sadece id si gönderilen markayı geri döndüren metot
        {
            return context.Markalar.Find(id);
        }
        /// <summary>
        /// Marka ekleme metodu
        /// </summary>
        /// <param name="marka"></param>
        /// <returns></returns>
        public int Add(Marka marka)
        {
            context.Markalar.Add(marka);
            return context.SaveChanges();// Bu metot geriye int değer döndürüyor.
        }
        /// <summary>
        /// Marka güncelleme metodu
        /// </summary>
        /// <param name="marka"></param>
        /// <returns></returns>
        public int Update(Marka marka)
        {
            context.Markalar.AddOrUpdate(marka);
            return context.SaveChanges();
        }
        /// <summary>
        /// Marka silme metodu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            context.Markalar.Remove(Get(id));
            return context.SaveChanges();
        }
    }
}