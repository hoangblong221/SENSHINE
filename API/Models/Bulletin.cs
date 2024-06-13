using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Bulletin
    {
        public int BulletinId { get; set; }
        public int? SpaId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? PostedDate { get; set; }
        public bool? IsImportant { get; set; }

        public virtual Spa? Spa { get; set; }
    }
}
