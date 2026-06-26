using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities;

public partial class GameRecovery
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public Guid GameGuid { get; set; }

    public int Seed { get; set; }

    public DateTime LastPlayed { get; set; }

    public virtual ICollection<ReplayStep> ReplaySteps { get; set; } = new List<ReplayStep>();

    public virtual AspNetUser User { get; set; } = null!;
}
