using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;
using RajiNet.ViewModels;

namespace RajiNet.Repositories
{
    public class SongRepository : GenericRepository<Song, SongVM>, IRepository<Song, SongVM>
    {
        public SongRepository(RajiNetDbContext _db) 
        {
            this.db = _db;
            this.TModel = db.Set<Song>();
        }

        public override List<SongVM> GetAll() 
        {
            return FetchAndPopulateAll()
                .ToList();
        }        
        
        public override SongVM GetById(int id) 
        {
            return FetchAndPopulateAll()
                .Where(song => song.Id == id)
                .FirstOrDefault();
        }


        private IQueryable<SongVM> FetchAndPopulateAll()
        {
            return TModel
                .Include(song => song.Album)
                    .ThenInclude(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Include(song => song.ArtistSong)
                    .ThenInclude(artist => artist.Artist)
                .Select(song => populateSong(song));
        }

        private SongVM populateSong(Song song)
        {
            return new SongVM {
                Id=song.Id,
                Name=song.Name,
                FileUrl=song.FileUrl,
                Album = new SongAlbumVM 
                {
                    Id=song.Album.Id,
                    Name=song.Album.Name,
                    SingleType=song.Album.SingleType,
                    ReleaseDate=song.Album.ReleaseDate,
                    Artists=song.Album.AlbumArtist
                        .Select(aa => aa.Artist)
                        .Select(a => new SongArtistVM 
                        {
                            Id=a.Id,
                            Image=a.Image,
                            Name=a.Name,
                        })
                        .ToList(),
                },
                Artists = song.ArtistSong
                    .Select(aa => aa.Artist)
                    .Select(a => new SongArtistVM 
                    {
                        Id=a.Id,
                        Image=a.Image,
                        Name=a.Name,
                    })
                    .ToList(),
            };
        }
    }
}