﻿using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class SaleItem
    {
        public int SaleItemId { get; set; }
        public int? SaleId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Sale? Sale { get; set; }
    }
}
