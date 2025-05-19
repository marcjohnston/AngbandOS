// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CelephaisTown : TownGameConfiguration
{
    public override string[] StoreFactoryNames => new string[] {
        nameof(GeneralStoreFactory),
        nameof(ArmoryStoreFactory),
        nameof(WeaponStoreFactory),
        nameof(TempleStoreFactory),
        nameof(TempleStoreFactory),
        nameof(AlchemistStoreFactory),
        nameof(MagicStoreFactory),
        nameof(HomeStoreFactory),
        nameof(LibraryStoreFactory),
        nameof(InnStoreFactory),
        nameof(HallStoreFactory),
        nameof(PawnStoreFactory)
    };

    /// <summary>
    /// Returns the Celephais dungeon because it is the dungeon under the city of Celephais.
    /// </summary>
    public override string DungeonName => nameof(CelephaisDungeon);

    public override int HousePrice => 50000;
    public override string Name => "the beautiful city of Celephais";
    public override char Char => 'C';
}