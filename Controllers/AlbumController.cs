using Microsoft.AspNetCore.Mvc;
using RajiNet.Models;
using RajiNet.Repositories;
using RajiNet.ViewModels;

namespace RajiNet.Controllers
{
    [Route("api/albums")]
    public class AlbumController : GenericController<Album, AlbumVM> {
        public AlbumController(IRepository<Album, AlbumVM> _repo) 
        {
            this.repo = _repo;
        }
    }
}