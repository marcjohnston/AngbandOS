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
internal abstract class Town : IGetKey
{
    protected readonly Game Game;

    /// <summary>
    /// Represents the RND seed that is used to generate the town.  This ensures the town is regenerated the same when the player returns.
    /// </summary>
    public int Seed = 0;
    public bool Visited = false;

    /// <summary>
    /// Returns the wilderness X coordinate of the town.
    /// </summary>
    public int X = 0;

    /// <summary>
    /// Returns the wilderness Y coordinate of the town.
    /// </summary>
    public int Y = 0;

    /// <summary>
    /// Returns the dungeon that is under the city.  This property is bound from the DungeonName property during the bind phase.
    /// </summary>
    public Dungeon Dungeon { get; private set; }

    /// <summary>
    /// Returns the name of the dungeon that is under the city.  This property is bound to the Dungeon property during the bind phase.
    /// </summary>
    public abstract string DungeonName { get; }

    public virtual bool AllowStartupTown => true;
    public abstract char Char { get; }
    public abstract int HousePrice { get; }
    public abstract string Name { get; }

    /// <summary>
    /// Returns the store factories that are used to generate the stores for the town.  This property is bound using the StoreFactoryNames property
    /// during the bind phase.
    /// </summary>
    public StoreFactory[] StoreFactories { get; private set; }

    /// <summary>
    /// Returns the stores that belong to the town.
    /// </summary>
    public Store[] Stores { get; private set; }
    protected abstract string[] StoreFactoryNames { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    protected Town(Game game)
    {
        Game = game;
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
        List<StoreFactory> storeFactoryList = new List<StoreFactory>();
        foreach (string storeName in StoreFactoryNames)
        {
            storeFactoryList.Add(Game.SingletonRepository.StoreFactories.Get(storeName));
        }
        StoreFactories = storeFactoryList.ToArray();

        Dungeon = Game.SingletonRepository.Get<Dungeon>(DungeonName);
    }

    public void Initialize()
    {
        Seed = Game.RandomLessThan(int.MaxValue);
        Visited = false;
        X = 0;
        Y = 0;

        List<Store> stores = new List<Store>();
        foreach (StoreFactory storeFactory in StoreFactories)
        {
            Store store = new Store(Game, storeFactory);
            store.StoreInit();
            store.StoreMaint();
            stores.Add(store);
        }
        Stores = stores.ToArray();
    }

    public string ToJson()
    {
        TownDefinition townDefinition = new()
        {
            Key = Key,
            DungeonName = DungeonName,
            HousePrice = HousePrice,
            Name = Name,
            Char = Char,
            StoreFactoryNames = Stores.Select(_store => _store.StoreFactory.Key).ToArray(),
        };
        return JsonSerializer.Serialize<TownDefinition>(townDefinition);
    }
}