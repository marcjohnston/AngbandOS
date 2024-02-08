// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.Shopkeepers;

[Serializable]
internal abstract class Shopkeeper : IGetKey<string>, IToJson
{
    protected SaveGame SaveGame { get; }
    public abstract int MaxCost { get; }

    /// <summary>
    /// Returns the minimum inflation value for this store owner.
    /// </summary>
    public abstract int MinInflate { get; }

    /// <summary>
    /// Returns the name of the owner.  For stores with no owner, this is the name of the store.
    /// </summary>
    public abstract string Name { get; }

    public virtual string Key => GetType().Name;

    /// <summary>
    /// Returns the race of the store owner.  Null, if there is no store owner.
    /// </summary>
    public Race? OwnerRace { get; private set; }

    protected abstract string? RaceName { get; }

    public string GetKey => Key;

    protected Shopkeeper(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public void Bind()
    {
        if (RaceName == null)
        {
            OwnerRace = null;
        }
        else
        {
            OwnerRace = SaveGame.SingletonRepository.Races.Get(RaceName);
        }
    }

    public string ToJson()
    {
        ShopkeeperDefinition shopkeeperDefinition = new()
        {
            Key = Key,
            MaxCost = MaxCost,
            MinInflate = MinInflate,
            Name = Name,
            RaceName = OwnerRace?.GetKey
        };
        return JsonSerializer.Serialize<ShopkeeperDefinition>(shopkeeperDefinition);
    }
}
