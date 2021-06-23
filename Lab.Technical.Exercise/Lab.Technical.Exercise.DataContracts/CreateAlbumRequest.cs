using Lab.Technical.Exercise.DataContracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Technical.Exercise.DataContracts
{
    public class CreateAlbumRequest
    {
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }
        public int LabelId { get; set; }
        public AlbumType AlbumType { get; set; }
        public int Stock { get; set; }
    }
}
