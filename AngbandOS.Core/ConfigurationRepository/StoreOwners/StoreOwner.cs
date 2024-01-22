// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;
using System.Text.Json;

namespace AngbandOS.Core.StoreOwners;

[Serializable]
internal abstract class StoreOwner : IGetKey<string>, IToJson
{
    protected SaveGame SaveGame { get; }
    public abstract int MaxCost { get; }
    public abstract int MinInflate { get; }

    /// <summary>
    /// Returns the name of the owner.  For stores with no owner, this is the name of the store.
    /// </summary>
    public abstract string OwnerName { get; }

    public virtual string Key => GetType().Name;

    /// <summary>
    /// Returns the race of the store owner.  Null, if there is no store owner.
    /// </summary>
    public Race? OwnerRace { get; private set; }

    protected abstract string? OwnerRaceName { get; }

    public string GetKey => Key;

    protected StoreOwner(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public void Bind()
    {
        if (OwnerRaceName == null)
        {
            OwnerRace = null;
        }
        else
        {
            OwnerRace = SaveGame.SingletonRepository.Races.Get(OwnerRaceName);
        }
    }

    public string ToJson()
    {
        StoreOwnerDefinition storeOwnerDefinition = new()
        {
            Key = Key,
            MaxCost = MaxCost,
            MinInflate = MinInflate,
            OwnerName = OwnerName,
            OwnerRaceName = OwnerRace?.GetKey
        };
        return JsonSerializer.Serialize<StoreOwnerDefinition>(storeOwnerDefinition);
    }
}
