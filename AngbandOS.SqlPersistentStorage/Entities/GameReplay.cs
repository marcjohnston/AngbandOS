using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class GameReplay
    {
        public GameReplay()
        {
            ReplaySteps = new HashSet<ReplayStep>();
        }

        public Guid GameGuid { get; set; }
        public int Seed { get; set; }
        public int ReplayId { get; set; }

        public virtual ICollection<ReplayStep> ReplaySteps { get; set; }
    }
}
