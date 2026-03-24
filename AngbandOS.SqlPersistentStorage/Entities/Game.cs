using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class Game
    {
        public int Id { get; set; }
        public int Seed { get; set; }
        public string Username { get; set; } = null!;
        public int Level { get; set; }
        public int Gold { get; set; }
        public string CharacterName { get; set; } = null!;
        public string Comments { get; set; } = null!;
        public bool IsAlive { get; set; }
        public DateTime DateTime { get; set; }
    }
}
