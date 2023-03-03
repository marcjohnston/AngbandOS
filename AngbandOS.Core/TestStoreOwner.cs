using AngbandOS.Core.StoreOwners;

namespace AngbandOS.Core;
internal class JsonStoreOwner
{
    public string OwnerName { get; set; }
    public int MaxCost { get; set; }
    public int MinInflate { get; set; }
}


[Serializable]
internal class DbStoreOwner : StoreOwner
{
    private string _ownerName;
    private int _maxCost;
    private int _minInflate;
    private Race? _ownerRace;
    public override string OwnerName => _ownerName;
    public override int MaxCost => _maxCost;
    public override int MinInflate => _minInflate;
    public override Race? OwnerRace => _ownerRace;
    public DbStoreOwner(SaveGame saveGame, JsonStoreOwner jsonStoreOwner) : base(saveGame)
    {
        _ownerName = jsonStoreOwner.OwnerName;
        _maxCost = jsonStoreOwner.MaxCost;
        _minInflate = jsonStoreOwner.MinInflate;
        _ownerRace = SaveGame.SingletonRepository.Races.Get<HumanRace>();
    }
}


[Serializable]
internal class DbStore : Store
{
    public override StoreType StoreType => StoreType.StoreHome;

    private string _featureType;
    private StoreOwner[] _storeOwners;
    private char _character;
    private Colour _colour;
    public override string FeatureType => _featureType;

    protected override StoreOwner[] StoreOwners => _storeOwners;

    public override bool ItemMatches(Item item) => false;

    protected override StockStoreInventoryItem[] GetStoreTable() => null;
    public override char Character => _character;
    public override Colour Colour => _colour;
    public DbStore(SaveGame saveGame, char character, Colour colour, string featureType, string storeOwner) : base(saveGame)
    {
        _storeOwners = new StoreOwner[] { SaveGame.SingletonRepository.StoreOwners.Get(storeOwner) };
        _featureType = featureType;
        _character = character;
        _colour = colour;
    }
}

internal class JsonTown
{
    public char Char { get; set; }

    public int HousePrice { get; set; }

    public string Name { get; set; }

    public string[] StoreNames { get; set; }
}

[Serializable]
internal class DbTown : Town
{
    private char _char;
    private int _housePrice;
    private string _name;
    private Store[] _stores;
    public override char Char => _char;

    public override int HousePrice => _housePrice;

    public override string Name => _name;

    public override Store[] Stores => _stores;
    public DbTown(SaveGame saveGame, JsonTown town) : base(saveGame)
    {
        _char = town.Char;
        _housePrice = town.HousePrice;
        _name = town.Name;
        //_stores = town.Stores;
    }
}