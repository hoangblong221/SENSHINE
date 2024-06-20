using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class SystemSetting
    {
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string? Description { get; set; }
    }
}
