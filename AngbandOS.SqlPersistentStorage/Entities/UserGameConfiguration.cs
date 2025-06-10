using System;
using System.Collections.Generic;
namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class UserGameConfiguration
    {
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string JsonData { get; set; } = null!;
    }
}
