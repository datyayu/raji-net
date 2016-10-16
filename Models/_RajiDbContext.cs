using Microsoft.EntityFrameworkCore;
using RajiNet.Models.Joins;

namespace RajiNet.Models 
{
    public class RajiNetDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Song> Songs { get; set; } 


        protected override void OnModelCreating(ModelBuilder mb)
        {
            /* Mappings */
            AlbumArtist.AddMappings(mb);
            ArtistSong.AddMappings(mb);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./development.db");
        }
    }
}