using System.Linq;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;

namespace RajiNet.Repositories
{
    public class SongRepository : GenericRepository<Song> {
        public SongRepository(RajiNetDbContext _db) 
        {
            this.db = _db;
            this.TModel = db.Set<Song>();
        }

        public override object GetAll() 
        {
            return TModel
                .Include(song => song.Album)
                    .ThenInclude(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Include(song => song.ArtistSong)
                    .ThenInclude(artist => artist.Artist)
                .Select(song => populateSong(song))
                .ToList();
        }        
        
        public override object GetById(int id) 
        {
            return TModel
                .Where(song => song.Id == id)
                .Include(song => song.Album)
                    .ThenInclude(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Include(song => song.ArtistSong)
                    .ThenInclude(artist => artist.Artist)
                .Select(song => populateSong(song))
                .FirstOrDefault();
        }


        private object populateSong(Song song)
        {
            return new {
                song.Id,
                song.Name,
                song.FileUrl,
                Album = new {
                    song.Album.Id,
                    song.Album.Name,
                    song.Album.SingleType,
                    song.Album.ReleaseDate,
                    Artists = song.Album.AlbumArtist
                        .Select(aa => aa.Artist)
                        .Select(a => new {
                            a.Id,
                            a.Image,
                            a.Name,
                        }),
                },
                Artists = song.ArtistSong
                    .Select(aa => aa.Artist)
                    .Select(a => new {
                        a.Id,
                        a.Image,
                        a.Name,
                    })
            };
        }
    }
}