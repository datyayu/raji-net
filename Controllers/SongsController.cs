using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;

namespace RajiNet.Controllers
{
    [Route("api/songs")]
    public class SongsController : GenericController<Song> {
        public SongsController(SongRepository _repo) 
        {
            this.repo = _repo;
        }
    }
}