using System.Collections.Generic;
using RajiNet.Models;

namespace RajiNet.Repositories
{
    public interface IRepository<T, VM> 
        where T : Model
        where VM : class
    {
        List<VM> GetAll();
        VM GetById(int id);
        void Create(T t);
        void Update(int id, T t);
        void Destroy(int id);
    }
} 