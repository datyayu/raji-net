using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;

namespace RajiNet.Controllers
{
    [Route("api/albums")]
    public class AlbumsController : GenericController<Album> {
        public AlbumsController(AlbumRepository _repo) 
        {
            this.repo = _repo;
        }
    }
}