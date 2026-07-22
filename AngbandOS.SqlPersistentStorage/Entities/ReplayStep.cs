using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities;

public partial class ReplayStep
{
    public int Id { get; set; }

    public int GameReplayId { get; set; }

    public DateTime DateTime { get; set; }

    public string Keystroke { get; set; } = null!;

    public int Seed { get; set; }

    public virtual GameRecovery GameReplay { get; set; } = null!;
}
