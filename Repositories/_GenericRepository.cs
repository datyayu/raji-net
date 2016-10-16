using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;


namespace RajiNet.Repositories
{
    public class GenericRepository<T> : Controller where T : Model
     {
        public RajiNetDbContext db;
        public DbSet<T> TModel;
        

        public virtual object GetAll()
        {
            return TModel.ToList();
        }

        public virtual object GetById(int id)
        {
            return TModel
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }

        public virtual void Create(T newModel)
        {
            TModel.Add(newModel);
            db.SaveChanges();
        }

        public virtual void Update(int id, T updatedModel)
        {
            var entry = TModel.Where(m => m.Id == id).FirstOrDefault();
            
            if (entry == null) return;

            entry = updatedModel;
            entry.Id = id;

            db.Update(entry);
            db.SaveChanges();
        }


        public virtual void Delete(int id)
        {  
            var entry = TModel.Where(m => m.Id == id).FirstOrDefault();
            
            if (entry == null) return;

            db.Remove(entry);
        }
    }
}
