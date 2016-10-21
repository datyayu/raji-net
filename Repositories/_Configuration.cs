using Microsoft.Extensions.DependencyInjection;
using RajiNet.Models;
using RajiNet.ViewModels;

namespace RajiNet.Repositories
{
    public class RepositoriesConfiguration
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Album, AlbumVM>, AlbumRepository>();
            services.AddTransient<IRepository<Artist, ArtistVM>, ArtistRepository>();
            services.AddTransient<IRepository<Series, SeriesVM>, SeriesRepository>();
            services.AddTransient<IRepository<Song, SongVM>, SongRepository>();
        }
    }
}