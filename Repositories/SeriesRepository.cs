using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RajiNet.Models;
using RajiNet.ViewModels;

namespace RajiNet.Repositories
{
    public class SeriesRepository : GenericRepository<Series, SeriesVM> , IRepository<Series, SeriesVM>
    {
        public SeriesRepository(RajiNetDbContext _db) 
        {
            this.db = _db;
            this.TModel = db.Set<Series>();
        }

        public override List<SeriesVM> GetAll()
        {
            return FetchAndPopulateAll()
                .ToList();
        }

        public override SeriesVM GetById(int id)
        {
            return FetchAndPopulateAll()
                .Where(series => series.Id == id)
                .FirstOrDefault();
        }


        private IQueryable<SeriesVM> FetchAndPopulateAll()
        {
             return TModel
                .Include(series => series.Albums)
                    .ThenInclude(album => album.AlbumArtist)
                    .ThenInclude(aa => aa.Artist)
                .Select(series => populateSeries(series));
        }

        private SeriesVM populateSeries(Series series)
        {
            return new SeriesVM 
            {
                Id=series.Id,
                Image=series.Image,
                Name=series.Name,
                Albums=series.Albums
                    .Select(a => new SeriesAlbumVM 
                    {
                        Id=a.Id,
                        Image=a.Image,
                        Name=a.Name,
                        ReleaseDate=a.ReleaseDate,
                        SingleType=a.SingleType,
                        Artists=a.AlbumArtist
                            .Select(aa => aa.Artist)
                            .Select(art => new SeriesArtistVM 
                            {
                                Id=art.Id,
                                Name=art.Name,
                                Image=art.Image,
                            })
                            .ToList()
                    })
                    .ToList(),
            };
        }
    }
} 