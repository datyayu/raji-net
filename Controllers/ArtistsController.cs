using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;

namespace RajiNet.Controllers
{
    [Route("api/artists")]
    public class ArtistsController : GenericController<Artist> {
        public ArtistsController(ArtistRepository _repo) 
        {
            this.repo = _repo;
        }
    }
}