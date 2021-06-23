using Lab.Technical.Exercise.DataContracts.Enums;

namespace Lab.Technical.Exercise.DataContracts
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public Label Label { get; set; }
        public AlbumType Type { get; set; }
        public Stock Stock { get; set; }
    }
}