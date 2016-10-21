using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;
using RajiNet.ViewModels;

namespace RajiNet.Repositories 
{
    public class ArtistRepository : GenericRepository<Artist, ArtistVM>, IRepository<Artist, ArtistVM>
    {
        public ArtistRepository(RajiNetDbContext _db) 
        {
            this.db = _db;
            this.TModel = db.Set<Artist>();
        }

        public override List<ArtistVM> GetAll()
        {
            return FetchAndPopulateAll()
                .ToList();
        }

        public override ArtistVM GetById(int id) 
        {
            return FetchAndPopulateAll()
                .Where(artist => artist.Id == id)
                .FirstOrDefault();
        }

        private IQueryable<ArtistVM> FetchAndPopulateAll() 
        {
            return TModel
                .Include(artist => artist.AlbumArtist)
                    .ThenInclude(aa => aa.Album)
                .Select(artist => populateArtist(artist));
        }

        private ArtistVM populateArtist(Artist artist)
        {
            return new ArtistVM {
                Id=artist.Id,
                Name=artist.Name,
                Image=artist.Image,
                Biography=artist.Biography,
                Albums=artist.AlbumArtist
                    .Select(aa => aa.Album)
                    .Select(album => new ArtistAlbumVM {
                        Id=album.Id,
                        Name=album.Name,
                        Image=album.Image,
                        ReleaseDate=album.ReleaseDate,
                        SingleType=album.SingleType,
                    })
                    .ToList(),
            };
        }
    }
}