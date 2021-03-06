using System;
using System.Collections.Generic;

namespace Lab.Technical.Exercise.Domain.EntityModels
{
    public class Label
    {
        public Label()
        {
            Albums = new List<Album>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<Album> Albums { get; set; }
    }
}