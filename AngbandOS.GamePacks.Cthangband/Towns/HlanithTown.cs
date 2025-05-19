// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HlanithTown : TownGameConfiguration
{
    public override string[] StoreFactoryNames => new string[] {
        nameof(GeneralStoreFactory),
        nameof(ArmoryStoreFactory),
        nameof(EmptyLotStoreFactory),
        nameof(WeaponStoreFactory),
        nameof(EmptyLotStoreFactory),
        nameof(AlchemistStoreFactory),
        nameof(MagicStoreFactory),
        nameof(BlackMarketStoreFactory),
        nameof(HomeStoreFactory),
        nameof(LibraryStoreFactory),
        nameof(InnStoreFactory),
        nameof(HallStoreFactory)
    };


    /// <summary>
    /// Returns the Hlanith dungeon because it is the dungeon under the city of Hlanith.
    /// </summary>
    public override string DungeonName => nameof(HlanithDungeon);

    public override int HousePrice => 45000;
    public override string Name => "the market town of Hlanith";
    public override char Char => 'H';
}