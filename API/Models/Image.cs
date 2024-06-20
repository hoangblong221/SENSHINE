using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string? ImagePath { get; set; }
    }
}
