using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class GameRecovery
    {
        public GameRecovery()
        {
            ReplaySteps = new HashSet<ReplayStep>();
        }

        public int Id { get; set; }
        public Guid GameGuid { get; set; }
        public int Seed { get; set; }
        public DateTime LastPlayed { get; set; }

        public virtual ICollection<ReplayStep> ReplaySteps { get; set; }
    }
}
