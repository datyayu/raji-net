using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;
using RajiNet.ViewModels;

namespace RajiNet.Repositories 
{
    public class AlbumRepository : GenericRepository<Album, AlbumVM>, IRepository<Album, AlbumVM> 
    {
        public AlbumRepository(RajiNetDbContext _db) 
        {
            this.db = _db;
            this.TModel = db.Set<Album>();
        }


        public override List<AlbumVM> GetAll() {
            return FetchAndPopulateAll()
                .ToList();
        }

        public override AlbumVM GetById(int id) {
            return FetchAndPopulateAll()
                .Where(album => album.Id == id)
                .FirstOrDefault();
        }


        private IQueryable<AlbumVM> FetchAndPopulateAll() 
        {
            return TModel
                .Include(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Include(Album => Album.Songs)
                    .ThenInclude(song => song.ArtistSong)
                    .ThenInclude(artSong => artSong.Artist)
                .Select(album => populateAlbum(album));
        }


        private AlbumVM populateAlbum(Album album) {
            return new AlbumVM 
            {
                Id=album.Id,
                Image=album.Image,
                Name=album.Name,
                ReleaseDate=album.ReleaseDate,
                Artists=album.AlbumArtist
                    .Select(aa => aa.Artist)
                    .Select(art => new AlbumArtistVM 
                    { 
                        Id=art.Id, 
                        Image=art.Image, 
                        Name=art.Name,
                        Biography=art.Biography
                    })
                    .ToList(),
                Songs=album.Songs
                    .Select(song => new AlbumSongVM 
                    {
                        Id=song.Id,
                        Name=song.Name,
                        FileUrl=song.FileUrl,
                        Artists=song.ArtistSong
                            .Select(artSong => artSong.Artist)
                            .Select(artist => new AlbumSongArtistVM 
                            {
                                Id=artist.Id,
                                Name=artist.Name,
                                Image=artist.Image,
                            })
                            .ToList()
                    })
                    .ToList(),
            };
        }
    }
}