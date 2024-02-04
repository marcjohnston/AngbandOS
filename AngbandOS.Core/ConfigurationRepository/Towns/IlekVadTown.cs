// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class IlekVadTown : Town
{
    private IlekVadTown(SaveGame saveGame) : base(saveGame) { }

    protected override string[] StoreFactoryNames => new string[] {
        nameof(GeneralStoreFactory),
        nameof(ArmoryStoreFactory),
        nameof(WeaponStoreFactory),
        nameof(TempleStoreFactory),
        nameof(AlchemistStoreFactory),
        nameof(MagicStoreFactory),
        nameof(BlackMarketStoreFactory),
        nameof(HomeStoreFactory),
        nameof(LibraryStoreFactory),
        nameof(EmptyLotStoreFactory),
        nameof(InnStoreFactory),
        nameof(HallStoreFactory)
    };


    /// <summary>
    /// Returns the IlekVad dungeon because it is the dungeon under the city of IlekVad.
    /// </summary>
    public override string DungeonName => nameof(IlekVadDungeon);

    public override int HousePrice => 60000;
    public override string Name => "the city of Ilek-Vad";
    public override char Char => 'V';
}