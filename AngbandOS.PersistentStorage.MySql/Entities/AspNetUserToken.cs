using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.MySql.Entities
{
    public partial class Aspnetusertoken
    {
        public string UserId { get; set; } = null!;
        public string LoginProvider { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Value { get; set; }

        public virtual Aspnetuser User { get; set; } = null!;
    }
}
