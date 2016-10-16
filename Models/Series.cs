using System.Collections.Generic;

namespace RajiNet.Models
{
    public class Series : Model
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public string Image { get; set; }

        public virtual List<Album> Albums { get; set; } = new List<Album>();
    }
}
