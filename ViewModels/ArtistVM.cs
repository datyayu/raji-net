using System;
using System.Collections.Generic;

namespace RajiNet.ViewModels
{
    public class ArtistVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public List<ArtistAlbumVM> Albums { get; set; }
    }

    public class ArtistAlbumVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SingleType { get; set; }
    }
}