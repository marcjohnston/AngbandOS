using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.MySql.Entities
{
    public partial class Usersetting
    {
        public string UserId { get; set; } = null!;
        public string? FontName { get; set; }
        public int? FontSize { get; set; }
        public string? F1macro { get; set; }
        public string? F2macro { get; set; }
        public string? F3macro { get; set; }
        public string? F4macro { get; set; }
        public string? F5macro { get; set; }
        public string? F6macro { get; set; }
        public string? F7macro { get; set; }
        public string? F8macro { get; set; }
        public string? F9macro { get; set; }
        public string? F10macro { get; set; }
        public string? F11macro { get; set; }
        public string? F12macro { get; set; }
    }
}
