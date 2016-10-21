using System;
using System.Collections.Generic;

namespace RajiNet.ViewModels
{
    public class SongVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string FileUrl { get; set; }
        public SongAlbumVM Album { get; set; }
        public List<SongArtistVM> Artists { get; set; }
    }

    public class SongAlbumVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string SingleType { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<SongArtistVM> Artists { get; set; }
    }

    public class SongArtistVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
