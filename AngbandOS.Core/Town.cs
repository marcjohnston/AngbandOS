// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class Town : IGetKey, IToJson
{
    private readonly Game Game;
    public Town(Game game, TownGameConfiguration townGameConfiguration)
    {
        Game = game;
        Key = townGameConfiguration.Key ?? townGameConfiguration.GetType().Name;
        DungeonName = townGameConfiguration.DungeonName;
        HousePrice = townGameConfiguration.HousePrice;
        Name = townGameConfiguration.Name;
        Char = townGameConfiguration.Char;
        StoreFactoryNames = townGameConfiguration.StoreFactoryNames;
        AllowStartupTown = townGameConfiguration.AllowStartupTown;
    }

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
    public string DungeonName { get; }

    public bool AllowStartupTown { get; } = true;
    public char Char { get; }
    public int HousePrice { get; }
    public string Name { get; }

    /// <summary>
    /// Returns the store factories that are used to generate the stores for the town.  This property is bound using the StoreFactoryNames property
    /// during the bind phase.
    /// </summary>
    public StoreFactory[] StoreFactories { get; private set; }

    /// <summary>
    /// Returns the stores that belong to the town.
    /// </summary>
    public Store[] Stores { get; private set; }
    private string[] StoreFactoryNames { get; }

    public string Key { get; }

    public string GetKey => Key;

    /// <summary>
    /// Returns true, if unused store lots should be graveyards; false, for them to be fields.  In Kadath, unused fields are graveyards.
    /// </summary>
    public bool UnusedStoreLotsAreGraveyards => false;

    /// <summary>
    /// Returns true, if inns can escort the player to this town; false, otherwise.  Inns do not provide escort services to Kadath.
    /// </summary>
    public bool CanBeEscortedHere => true;

    public void Bind()
    {
        List<StoreFactory> storeFactoryList = new List<StoreFactory>();
        foreach (string storeName in StoreFactoryNames)
        {
            storeFactoryList.Add(Game.SingletonRepository.Get<StoreFactory>(storeName));
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
        TownGameConfiguration townDefinition = new()
        {
            Key = Key,
            DungeonName = DungeonName,
            HousePrice = HousePrice,
            Name = Name,
            Char = Char,
            AllowStartupTown = AllowStartupTown,
            CanBeEscortedHere = CanBeEscortedHere,
            UnusedStoreLotsAreGraveyards = UnusedStoreLotsAreGraveyards,
            StoreFactoryNames = Stores.Select(_store => _store.StoreFactory.Key).ToArray(),
        };
        return JsonSerializer.Serialize(townDefinition, Game.GetJsonSerializerOptions());
    }
}