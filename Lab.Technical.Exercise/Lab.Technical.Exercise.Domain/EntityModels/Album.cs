using Lab.Technical.Exercise.DataContracts.Enums;
using System;

namespace Lab.Technical.Exercise.Domain.EntityModels
{
    public class Album
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int LabelId { get; set; }
        public string Name { get; set; }
        public AlbumType AlbumType { get; set; }
        public Artist Artist { get; set; }
        public Label Label { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? UpdatedDate { get; set; }
        public Stock Stock { get; set; }
    }
}