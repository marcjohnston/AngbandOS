using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities;

public partial class SavedGameContent
{
    public int Id { get; set; }

    public byte[] Data { get; set; } = null!;

    public virtual ICollection<SavedGame> SavedGames { get; set; } = new List<SavedGame>();
}
