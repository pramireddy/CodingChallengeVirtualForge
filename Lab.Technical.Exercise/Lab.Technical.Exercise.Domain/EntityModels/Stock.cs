using System;

namespace Lab.Technical.Exercise.Domain.EntityModels
{
    public class Stock
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; private set; }
        //public Album Album { get; set; }
    }
}