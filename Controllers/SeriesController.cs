using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;

namespace RajiNet.Controllers
{
    [Route("api/series")]
    public class SeriesController : GenericController<Series> {
        public SeriesController(SeriesRepository _repo) 
        {
            this.repo = _repo;
        }
    }
}