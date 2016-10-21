using System;
using System.Collections.Generic;

namespace RajiNet.ViewModels
{
    public class AlbumVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<AlbumArtistVM> Artists { get; set; }
        public List<AlbumSongVM> Songs { get; set; }
    }

    public class AlbumArtistVM
    {
        public int Id { get; set; } 
        public string Image { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }

    public class AlbumSongVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string FileUrl { get; set; }
        public List<AlbumSongArtistVM> Artists { get; set; }
    }

    public class AlbumSongArtistVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}