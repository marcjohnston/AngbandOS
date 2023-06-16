// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class HlanithTown : Town
{
    private Store[] _stores;
    private HlanithTown(SaveGame saveGame) : base(saveGame)
    {
        _stores = new Store[]
        {
            new GeneralStore(SaveGame),
            new ArmouryStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new WeaponStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new AlchemistStore(SaveGame),
            new MagicStore(SaveGame),
            new BlackStore(SaveGame),
            new HomeStore(SaveGame),
            new LibraryStore(SaveGame),
            new InnStore(SaveGame),
            new HallStore(SaveGame)
        };
    }
    public override Store[] Stores => _stores;

    public override int HousePrice => 45000;
    public override string Name => "the market town of Hlanith";
    public override char Char => 'H';
}