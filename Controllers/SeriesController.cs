using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;
using RajiNet.ViewModels;

namespace RajiNet.Controllers
{
    [Route("api/series")]
    public class SeriesController : GenericController<Series, SeriesVM> {
        public SeriesController(IRepository<Series, SeriesVM> _repo) 
        {
            this.repo = _repo;
        }
    }
}