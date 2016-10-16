using System.Collections.Generic;
using RajiNet.Models.Joins;

namespace RajiNet.Models
{
    public class Song : Model
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public string FileUrl { get; set; }

        public virtual Album Album { get; set; }
        public virtual List<ArtistSong> ArtistSong { get; set; } = new List<ArtistSong>();
    }
}
