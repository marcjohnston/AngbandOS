using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class ReplayStep
    {
        public int Id { get; set; }
        public int GameReplayId { get; set; }
        public DateTime DateTime { get; set; }
        public byte Keystroke { get; set; }

        public virtual GameReplay GameReplay { get; set; } = null!;
    }
}
