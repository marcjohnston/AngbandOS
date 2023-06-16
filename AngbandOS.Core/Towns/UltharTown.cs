// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class UltharTown : Town
{
    private Store[] _stores;
    private UltharTown(SaveGame saveGame) : base(saveGame)
    {
        _stores = new Store[]
        {
            new GeneralStore(SaveGame),
            new ArmouryStore(SaveGame),
            new WeaponStore(SaveGame),
            new TempleStore(SaveGame),
            new AlchemistStore(SaveGame),
            new MagicStore(SaveGame),
            new EmptyLotStore(SaveGame),
            new HomeStore(SaveGame),
            new LibraryStore(SaveGame),
            new InnStore(SaveGame),
            new HallStore(SaveGame),
            new PawnStore(SaveGame)
        };
    }
    public override Store[] Stores => _stores;

    public override int HousePrice => 45000;
    public override string Name => "the picturesque town of Ulthar";
    public override char Char => 'U';
}