// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KothDungeon : DungeonGameConfiguration
{
    public override int BaseOffset => 40;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 20;
    public override string? BiasMonsterFilterName => nameof(MonsterRaceFiltersEnum.CthuloidMonsterRaceFilter);
    public override string[]? DungeonGuardianNames => new string[]
    {
        nameof(FatherDagonDungeonGuardian),
        nameof(TulzschaDungeonGuardian)
    };
    public override string Name => "the Tower of Koth";
    public override string Shortname => "Koth";
    public override string MapSymbol => "k";
}