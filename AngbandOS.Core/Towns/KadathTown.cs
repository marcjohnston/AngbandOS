// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class KadathTown : Town
{
    private Store[] _stores;
    private KadathTown(SaveGame saveGame) : base(saveGame)
    {
        _stores = new Store[]
        {
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new EmptyLotStore(SaveGame)
        };
    }
    public override Store[] Stores => _stores;

    public override int HousePrice => 0;
    public override string Name => "Kadath, home of the Gods";
    public override char Char => 'K';
}