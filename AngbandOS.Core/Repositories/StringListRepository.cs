// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

/// <summary>
/// Represents a ListRepository where all of the entities are strings.  This abstract class handles the string serialization for the repository entities.
/// </summary>
internal abstract class StringListRepository : ListRepository<string>
{
    protected StringListRepository(SaveGame saveGame) : base(saveGame) { }
    public override void PersistEntities()
    {
        List<KeyValuePair<string, string>> keyValuePairList = new List<KeyValuePair<string, string>>();
        foreach (string entity in this)
        {
            keyValuePairList.Add(new KeyValuePair<string, string>("", entity));
        }
        SaveGame.CorePersistentStorage.PersistEntities(Name, keyValuePairList.ToArray());
    }

    public override string SerializeEntity(string entity)
    {
        return entity;
    }
}
