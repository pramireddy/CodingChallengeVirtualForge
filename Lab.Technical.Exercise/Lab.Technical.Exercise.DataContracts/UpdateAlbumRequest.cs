using Lab.Technical.Exercise.DataContracts.Enums;

namespace Lab.Technical.Exercise.DataContracts
{
    public class UpdateAlbumRequest
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }
        public int LabelId { get; set; }
        public AlbumType AlbumType { get; set; }
        public int Stock { get; set; }
    }
}