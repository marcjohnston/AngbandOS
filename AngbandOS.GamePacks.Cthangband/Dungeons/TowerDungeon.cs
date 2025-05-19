// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TowerDungeon : DungeonGameConfiguration
{
    public override int BaseOffset => 13;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 17;
    public override string? BiasMonsterFilterName => nameof(MonsterRaceFiltersEnum.SpiderMonsterRaceFilter);
    public override string[]? DungeonGuardianNames => new string[]
    {
        nameof(ShelobSpiderOfDarknessDungeonGuardian)
    };
    public override string Name => "Shelob's Tower";
    public override string Shortname => "Tower";
    public override string MapSymbol => "s";
}