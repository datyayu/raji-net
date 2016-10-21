using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;

namespace RajiNet.Repositories
{
    public abstract class GenericRepository<T, VM> : Controller
            where T : Model 
            where VM : class
     {
        public RajiNetDbContext db;
        public DbSet<T> TModel;
        

        public abstract List<VM> GetAll();

        public abstract VM GetById(int id);

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


        public virtual void Destroy(int id)
        {  
            var entry = TModel.Where(m => m.Id == id).FirstOrDefault();
            
            if (entry == null) return;

            db.Remove(entry);
        }
    }
}
