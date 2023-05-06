﻿using Bootcamp.Data.Models;

namespace Bootcamp.Data.DTOs.Book
{
    public class PutBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
    }
}
