﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns;

[Serializable]
internal class DylathLeenTown : Town
{
    private DylathLeenTown(Game game) : base(game) { }
    protected override string[] StoreFactoryNames => new string[] {
        nameof(GeneralStoreFactory),
        nameof(ArmoryStoreFactory),
        nameof(WeaponStoreFactory),
        nameof(BlackMarketStoreFactory),
        nameof(BlackMarketStoreFactory),
        nameof(BlackMarketStoreFactory),
        nameof(HomeStoreFactory),
        nameof(LibraryStoreFactory),
        nameof(EmptyLotStoreFactory),
        nameof(InnStoreFactory),
        nameof(HallStoreFactory),
        nameof(PawnStoreFactory)
    };


    /// <summary>
    /// Returns the Dylath-Leen dungeon because it is the dungeon under the city of Dylath-Leen.
    /// </summary>
    public override string DungeonName => nameof(DylathLeenDungeon);

    public override int HousePrice => 25000;
    public override string Name => "the unwholesome city of Dylath-Leen";
    public override char Char => 'D';
}