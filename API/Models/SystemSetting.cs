using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class SystemSetting
    {
        public int SettingId { get; set; }
        public string? SettingName { get; set; }
        public string? SettingValue { get; set; }
    }
}
