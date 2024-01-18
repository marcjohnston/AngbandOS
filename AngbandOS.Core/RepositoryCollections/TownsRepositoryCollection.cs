// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Xml.Linq;

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class TownsRepositoryCollection : KeyedDictionaryRepositoryCollection<string, Town>
{
    public TownsRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    public override void Load()
    {
        if (SaveGame.Configuration.Towns == null)
        {
            base.Load();
        }
        else
        {
            foreach (TownDefinition townDefinition in SaveGame.Configuration.Towns)
            {
                Add(new GenericTown(SaveGame, townDefinition));
            }
        }
    }

    public override void Loaded()
    {
        foreach (Town town in this)
        {
            town.Loaded();
        }
    }

    protected override string? PersistedEntityName => "Town";

    protected override string? SerializeEntity(Town town)
    {
        TownDefinition townDefinition = new()
        {
            Key = town.Key,
            HousePrice = town.HousePrice,
            Name = town.Name,
            Char = town.Char,
            StoreNames = town.Stores.Select(_store => _store.Key).ToArray(),
        };
        return JsonSerializer.Serialize<TownDefinition>(townDefinition);
    }
}