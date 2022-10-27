using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class SavedGame
    {
        public Guid Guid { get; set; }
        public string Username { get; set; } = null!;
        public int Level { get; set; }
        public int Gold { get; set; }
        public string CharacterName { get; set; } = null!;
        public string Comments { get; set; } = null!;
        public bool IsAlive { get; set; }
        public DateTime DateTime { get; set; }
        public int SavedGameContentId { get; set; }

        public virtual SavedGameContent SavedGameContent { get; set; } = null!;
    }
}
