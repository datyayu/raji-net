using System;
using System.Collections.Generic;
using RajiNet.Models.Joins;

namespace RajiNet.Models
{
    public class SingleType {
        public static string OpSingle = "Op Single";
        public static string EdSingle = "ED Single";
        public static string CharacterSong = "Character Song";
        public static string OST = "OST";
        public static string Album = "Album";
        public static string MiniAlbum = "MiniAlbum";
    }

    public class Album : Model
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public string Image { get; set; }
        public string SingleType { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual List<AlbumArtist> AlbumArtist { get; set; } = new List<AlbumArtist>();
        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}