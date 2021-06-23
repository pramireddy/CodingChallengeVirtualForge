using System.Collections.Generic;

namespace Lab.Technical.Exercise.DataContracts
{
    public class AlbumFormOptionsData
    {
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Label> Labels { get; set; }
    }
}