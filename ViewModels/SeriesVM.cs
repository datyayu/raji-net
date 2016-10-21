using System;
using System.Collections.Generic;

namespace RajiNet.ViewModels
{
    public class SeriesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<SeriesAlbumVM> Albums { get; set; }
    }

    public class SeriesAlbumVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SingleType { get; set; }
        public List<SeriesArtistVM> Artists { get; set; }
    }

    public class SeriesArtistVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}