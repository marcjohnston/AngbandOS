// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

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

    public GenericTown(SaveGame saveGame, string serializedJson) : base(saveGame)
    {
        JsonTown? jsonDefinition = JsonSerializer.Deserialize<JsonTown>(serializedJson);
        if (jsonDefinition == null)
        {
            throw new Exception("The singleton object failed to deserialize.");
        }
        if (jsonDefinition.Char == null)
        {
            throw new Exception("The Town.Char property failed to deserialize.");
        }
        if (jsonDefinition.HousePrice == null || jsonDefinition.Name == null || jsonDefinition.Stores == null)
        {
            throw new Exception("The Town.HousePrice property failed to deserialize.");
        }
        if (jsonDefinition.Name == null)
        {
            throw new Exception("The Town.Name property failed to deserialize.");
        }
        if (jsonDefinition.Stores == null)
        {
            throw new Exception("The Town.StoreNames property failed to deserialize.");
        }
        _housePrice = jsonDefinition.HousePrice.Value;
        _name = jsonDefinition.Name;
        _character = jsonDefinition.Char.Value;
        _storeNames = jsonDefinition.Stores;
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
