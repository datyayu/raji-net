using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;

namespace RajiNet.Controllers
{
    public abstract class GenericController<T, VM> : Controller
            where T : Model 
            where VM : class
     {
        public IRepository<T, VM> repo;

        // GET api/[controller]
        [HttpGet]
        public virtual List<VM> Index() 
        {
            return repo.GetAll();
        }

        // GET api/[controller]/5
        [HttpGet("{id}")]
        public virtual VM Show(int id)
        {
            return repo.GetById(id);
        }

        // POST api/[controller]
        [HttpPost]
        public virtual void Create([FromBody]T newModel)
        {
            repo.Create(newModel);
        }

        // PUT api/[controller]/5
        [HttpPut("{id}")]
        public virtual void Update(int id, [FromBody]T updatedModel)
        {
            repo.Update(id, updatedModel);
        }

        // DELETE api/[controller]/5
        [HttpDelete("{id}")]
        public virtual void Destroy(int id)
        {  
            repo.Destroy(id);
        }
    }
}
