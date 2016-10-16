using System.Linq;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;

namespace RajiNet.Repositories 
{
    public class ArtistRepository : GenericRepository<Artist>
    {
        public ArtistRepository(RajiNetDbContext _db) 
        {
            this.db = _db;
            this.TModel = db.Set<Artist>();
        }

        public override object GetAll()
        {
            return TModel
                .Include(artist => artist.AlbumArtist)
                    .ThenInclude(aa => aa.Album)
                .Select(artist => populateArtist(artist))
                .ToList();
        }

        public override object GetById(int id) 
        {
            return TModel
                .Where(artist => artist.Id == id)
                .Include(artist => artist.AlbumArtist)
                    .ThenInclude(aa => aa.Album)
                .Select(artist => populateArtist(artist))
                .FirstOrDefault();
        }

        private object populateArtist(Artist artist)
        {
            return new {
                artist.Id,
                artist.Name,
                artist.Image,
                artist.Biography,
                Albums = artist.AlbumArtist
                    .Select(aa => aa.Album)
                    .Select(album => new {
                        album.Id,
                        album.Name,
                        album.Image,
                        album.ReleaseDate,
                        album.SingleType,
                    })
            };
        }
    }
}