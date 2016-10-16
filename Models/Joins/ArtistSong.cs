using Microsoft.EntityFrameworkCore;

namespace RajiNet.Models.Joins {
    public class ArtistSong {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }


        public static void AddMappings(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ArtistSong>()
                .HasKey(t => new { t.ArtistId, t.SongId });

            modelBuilder.Entity<ArtistSong>()
                .HasOne(aa => aa.Song)
                .WithMany(a => a.ArtistSong)
                .HasForeignKey(aa => aa.SongId);

            modelBuilder.Entity<ArtistSong>()
                .HasOne(aa => aa.Artist)
                .WithMany(a => a.ArtistSong)
                .HasForeignKey(aa => aa.ArtistId);
        }
    }
}