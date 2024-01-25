using System;
using System.Collections.Generic;

namespace Bookpage.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Year { get; set; }
        public string Genre { get; set; } = null!;
    }
}
