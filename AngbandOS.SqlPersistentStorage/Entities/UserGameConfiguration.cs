using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class UserGameConfiguration
    {
        public UserGameConfiguration()
        {
            GameConfigurations = new HashSet<GameConfiguration>();
        }

        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public Guid Guid { get; set; }

        public virtual ICollection<GameConfiguration> GameConfigurations { get; set; }
    }
}
