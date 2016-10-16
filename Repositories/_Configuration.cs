using Microsoft.Extensions.DependencyInjection;

namespace RajiNet.Repositories
{
    public class RepositoriesConfiguration
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<AlbumRepository>();
            services.AddScoped<ArtistRepository>();
            services.AddScoped<SeriesRepository>();
            services.AddScoped<SongRepository>();
        }
    }
}