// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class UltharDungeon : DungeonGameConfiguration
{
    public override int BaseOffset => 0;
    public override int MaxLevel => 7;
    public override string? BiasMonsterFilterName => nameof(MonsterRaceFiltersEnum.AnimalMonsterRaceFilter);
    public override string[]? DungeonGuardianNames => new string[]
    {
        nameof(HobbesTheTigerMonsterRaceDungeonGuardian)
    };
    public override string Name => "the Sewers under Ulthar";
    public override string Shortname => "Ulthar";
    public override string MapSymbol => "U";
}