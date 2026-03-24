using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class RepositoryEntity
    {
        public string RepositoryName { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string JsonData { get; set; } = null!;
    }
}
