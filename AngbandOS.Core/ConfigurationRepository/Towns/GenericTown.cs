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
    private int _housePrice;
    private string _name;
    private char _character;
    private Store[] _stores;

    public GenericTown(SaveGame saveGame, TownDefinition townDefinition) : base(saveGame)
    {
        _housePrice = townDefinition.HousePrice;
        _name = townDefinition.Name;
        _character = townDefinition.Char;

        List<Store> stores = new List<Store>();
        if (townDefinition.StoreNames != null)
        {
            foreach (string storeName in townDefinition.StoreNames)
            {
                Store? store = SaveGame.SingletonRepository.Stores.TryGet(storeName);
                if (store == null)
                {
                    throw new Exception($"Town '{Name}' cannot find store '{storeName}'.");
                }
                stores.Add(store);
            }
        }
        _stores = stores.ToArray();
    }

    public override Store[] Stores => _stores;
    public override int HousePrice => _housePrice;
    public override string Name => _name;
    public override char Char => _character;
}
