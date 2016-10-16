using System.Collections.Generic;
using RajiNet.Models.Joins;

namespace RajiNet.Models
{
    public class Artist : Model
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; } = "";

        public virtual List<AlbumArtist> AlbumArtist { get; set; } = new List<AlbumArtist>();
        public virtual List<ArtistSong> ArtistSong { get; set; } = new List<ArtistSong>();
    }
}
