// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class YeekDungeon : DungeonGameConfiguration
{
    public override int BaseOffset => 2;
    public override int MaxLevel => 8;
    public override string? BiasMonsterFilterName => nameof(MonsterRaceFiltersEnum.YeekMonsterRaceFilter);
    public override string[]? DungeonGuardianNames => new string[]
    {
        nameof(OrfaxSonOfBoldorDungeonGuardian),
        nameof(BoldorKingOfTheYeeksDungeonGuardian)
    };
    public override string Name => "the Yeek King's Lair";
    public override string Shortname => "Yeek Lair";
    public override string MapSymbol => "y";
}