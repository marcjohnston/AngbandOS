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
    private UltharTown(SaveGame saveGame) : base(saveGame) { }
    protected override string[] StoreFactoryNames => new string[] {
        nameof(GeneralStoreFactory),
        nameof(ArmoryStoreFactory),
        nameof(WeaponStoreFactory),
        nameof(TempleStoreFactory),
        nameof(AlchemistStoreFactory),
        nameof(MagicStoreFactory),
        nameof(EmptyLotStoreFactory),
        nameof(HomeStoreFactory),
        nameof(LibraryStoreFactory),
        nameof(InnStoreFactory),
        nameof(HallStoreFactory),
        nameof(PawnStoreFactory)
    };


    /// <summary>
    /// Returns the Ulthar dungeon because it is the dungeon under the city of Ulthar.
    /// </summary>
    public override string DungeonName => nameof(UltharDungeon);

    public override int HousePrice => 45000;
    public override string Name => "the picturesque town of Ulthar";
    public override char Char => 'U';
}