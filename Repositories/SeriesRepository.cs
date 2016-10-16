using System.Linq;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;

namespace RajiNet.Repositories
{
    public class SeriesRepository : GenericRepository<Series> {
        public SeriesRepository(RajiNetDbContext _db) 
        {
            this.db = _db;
            this.TModel = db.Set<Series>();
        }

        public override object GetAll()
        {
            return TModel
                .Include(series => series.Albums)
                    .ThenInclude(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Select(series => populateSeries(series))
                .ToList();
        }

        public override object GetById(int id)
        {
            return TModel
                .Where(series => series.Id == id)
                .Include(series => series.Albums)
                    .ThenInclude(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Select(series => populateSeries(series))
                .FirstOrDefault();
        }

        private object populateSeries(Series series)
        {
            return new {
                series.Id,
                series.Image,
                series.Name,
                Albums = series.Albums.Select(a => new {
                    a.Id,
                    a.Image,
                    a.Name,
                    a.ReleaseDate,
                    a.SingleType,
                    a.Songs,
                    Artists = a.AlbumArtist
                        .Select(aa => aa.Artist)
                        .Select(artist => new {
                            artist.Id,
                            artist.Image,
                            artist.Name,
                            artist.Biography,
                        })
                }),
            };
        }
    }
}