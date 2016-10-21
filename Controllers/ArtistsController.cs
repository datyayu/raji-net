using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;
using RajiNet.ViewModels;

namespace RajiNet.Controllers
{
    [Route("api/artists")]
    public class ArtistsController : GenericController<Artist, ArtistVM> {
        public ArtistsController(IRepository<Artist, ArtistVM> _repo) 
        {
            this.repo = _repo;
        }
    }
}