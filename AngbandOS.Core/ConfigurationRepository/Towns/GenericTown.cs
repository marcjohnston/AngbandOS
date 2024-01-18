// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.Towns;

[Serializable]
internal class GenericTown : Town
{
    private readonly string _key;
    private readonly int _housePrice;
    private readonly string _name;
    private readonly char _char;
    private readonly string[] _storeNames;

    private Store[] _stores;

    public GenericTown(SaveGame saveGame, TownDefinition townDefinition) : base(saveGame)
    {
        _key = townDefinition.Key;
        _housePrice = townDefinition.HousePrice;
        _name = townDefinition.Name;
        _char = townDefinition.Char;
        _storeNames = townDefinition.StoreNames;
    }

    public override string Key => _key;
    public override Store[] Stores => _stores;
    public override int HousePrice => _housePrice;
    public override string Name => _name;
    public override char Char => _char;

    public override void Loaded()
    {
        List<Store> stores = new List<Store>();
        foreach (string storeName in _storeNames)
        {
            Store store = SaveGame.SingletonRepository.Stores.Get(storeName);
            stores.Add(store);
        }
        _stores = stores.ToArray();
    }
}
