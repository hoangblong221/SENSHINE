using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Image
    {
        public Image()
        {
            IdProducts = new HashSet<Product>();
        }

        public int IdImg { get; set; }
        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<Product> IdProducts { get; set; }
    }
}
