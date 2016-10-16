using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;

namespace RajiNet.Controllers
{
    public class GenericController<T> : Controller where T : Model
     {
        public GenericRepository<T> repo;

        // GET api/[controller]
        [HttpGet]
        public virtual object Get()
        {
            return repo.GetAll();
        }

        // GET api/[controller]/5
        [HttpGet("{id}")]
        public virtual object Get(int id)
        {
            return repo.GetById(id);
        }

        // POST api/[controller]
        [HttpPost]
        public virtual void Post([FromBody]T newModel)
        {
            repo.Create(newModel);
        }

        // PUT api/[controller]/5
        [HttpPut("{id}")]
        public virtual void Put(int id, [FromBody]T updatedModel)
        {
            repo.Update(id, updatedModel);
        }

        // DELETE api/[controller]/5
        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {  
            repo.Delete(id);
        }
    }
}
