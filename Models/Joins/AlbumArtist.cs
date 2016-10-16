using Microsoft.EntityFrameworkCore;

namespace RajiNet.Models.Joins {
    public class AlbumArtist {
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }


        public static void AddMappings(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<AlbumArtist>()
                .HasKey(t => new { t.ArtistId, t.AlbumId });

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(aa => aa.Album)
                .WithMany(a => a.AlbumArtist)
                .HasForeignKey(aa => aa.AlbumId);

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(aa => aa.Artist)
                .WithMany(a => a.AlbumArtist)
                .HasForeignKey(aa => aa.ArtistId);
        }
    }
}