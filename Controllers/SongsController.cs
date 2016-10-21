using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;
using RajiNet.ViewModels;

namespace RajiNet.Controllers
{
    [Route("api/songs")]
    public class SongsController : GenericController<Song, SongVM> {
        public SongsController(IRepository<Song, SongVM> _repo) 
        {
            this.repo = _repo;
        }
    }
}