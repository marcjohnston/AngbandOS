// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class GenericTown : Town
{
    private int _housePrice;
    private string _name;
    private char _character;
    private string[] _storeNames;

    /// <summary>
    /// Returns the stores that are found in the town.
    /// </summary>
    private Store[] _stores;

    public GenericTown(SaveGame saveGame, TownDefinition jsonTown) : base(saveGame)
    {
        _housePrice = jsonTown.HousePrice;
        _name = jsonTown.Name;
        _character = jsonTown.Char;
        _storeNames = jsonTown.Stores;
    }

    public override Store[] Stores => _stores;
    public override int HousePrice => _housePrice;
    public override string Name => _name;
    public override char Char => _character;

    /// <summary>
    /// Performs the binding for generic towns to bind to stores.
    /// </summary>
    /// <exception cref="Exception"></exception>
    public override void Loaded()
    {
        List<Store> stores = new List<Store>();
        foreach (string storeName in _storeNames)
        {
            Store? store = SaveGame.SingletonRepository.Stores.TryGet(storeName);
            if (store == null)
            {
                throw new Exception($"Town '{Name}' cannot find store '{storeName}'.");
            }
            stores.Add(store);
        }
        _stores = stores.ToArray();
    }
}
