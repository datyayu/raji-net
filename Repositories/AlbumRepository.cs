using System.Linq;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;

namespace RajiNet.Repositories 
{
    public class AlbumRepository : GenericRepository<Album>
    {
        public AlbumRepository(RajiNetDbContext _db) 
        {
            this.db = _db;
            this.TModel = db.Set<Album>();
        }


        public override object GetAll() {
            return TModel
                .Include(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Include(Album => Album.Songs)
                    .ThenInclude(song => song.ArtistSong)
                    .ThenInclude(artSong => artSong.Artist)
                .Select(album => populateAlbum(album));
        }

        public override object GetById(int id) {
            return TModel
                .Where(album => album.Id == id)
                .Include(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Include(Album => Album.Songs)
                    .ThenInclude(song => song.ArtistSong)
                    .ThenInclude(artSong => artSong.Artist)
                .Select(album => populateAlbum(album))
                .FirstOrDefault();
        }


        private object populateAlbum(Album album) {
            return new {
                album.Id,
                album.Image,
                album.Name,
                album.ReleaseDate,
                Artists=album.AlbumArtist
                    .Select(aa => aa.Artist)
                    .Select(art => new { 
                        art.Id, 
                        art.Image, 
                        art.Name, art.Biography 
                    }),
                Songs=album.Songs
                    .Select(song => new {
                        song.Id,
                        song.Name,
                        song.FileUrl,
                        Artists=song.ArtistSong
                            .Select(artSong => artSong.Artist)
                            .Select(artist => new {
                                artist.Id,
                                artist.Name,
                                artist.Image,
                            })
                    }),
            };
        }
    }
}