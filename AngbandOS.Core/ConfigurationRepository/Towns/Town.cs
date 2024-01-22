// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;
using System.Text.Json;

namespace AngbandOS.Core.Towns;

[Serializable]
internal abstract class Town : IGetKey<string>, IToJson
{
    protected readonly SaveGame SaveGame;

    /// <summary>
    /// Represents the RND seed that is used to generate the town.  This ensures the town is regenerated the same when the player returns.
    /// </summary>
    public int Seed = 0;
    public bool Visited = false;
    public int X = 0;
    public int Y = 0;
    public int Index;

    public virtual bool AllowStartupTown => true;
    public abstract char Char { get; }
    public abstract int HousePrice { get; }
    public abstract string Name { get; }
    public Store[] Stores { get; private set; }
    protected abstract string[] StoreFactoryNames { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    protected Town(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns true, if unused store lots should be graveyards; false, for them to be fields.  In Kadath, unused fields are graveyards.
    /// </summary>
    public virtual bool UnusedStoreLotsAreGraveyards => false;

    /// <summary>
    /// Returns true, if inns can escort the player to this town; false, otherwise.  Inns do not provide escort services to Kadath.
    /// </summary>
    public virtual bool CanBeEscortedHere => true;

    public void Bind()
    {
        List<Store> stores = new List<Store>();
        foreach (string storeName in StoreFactoryNames)
        {
            StoreFactory storeFactory = SaveGame.SingletonRepository.Stores.Get(storeName);
            stores.Add(new Store(SaveGame, storeFactory));
        }
        Stores = stores.ToArray();
    }

    public string ToJson()
    {
        TownDefinition townDefinition = new()
        {
            Key = Key,
            HousePrice = HousePrice,
            Name = Name,
            Char = Char,
            StoreFactoryNames = Stores.Select(_store => _store.StoreFactory.Key).ToArray(),
        };
        return JsonSerializer.Serialize<TownDefinition>(townDefinition);
    }
}