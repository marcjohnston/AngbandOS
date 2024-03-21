// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.Repositories;

/// <summary>
/// Represents a ListRepository where all of the entities are strings.  This abstract class handles the string serialization for the repository entities.
/// </summary>
[Serializable]
internal abstract class StringListRepository : ListRepository<string>
{
    protected StringListRepository(Game game) : base(game) { }
    public override void PersistEntities()
    {
        List<string> values = new List<string>();
        foreach (string entity in this)
        {
            values.Add(entity);
        }
        string json = JsonSerializer.Serialize(values);
        Game.CorePersistentStorage.PersistEntity(Name, json);
    }

    public override string SerializeEntity(string entity)
    {
        return entity;
    }
}
