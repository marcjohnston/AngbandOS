// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KadathDungeon : DungeonGameConfiguration
{
    public override int BaseOffset => 50;
    public override int MaxLevel => 75;
    public override string? BiasMonsterFilterName => nameof(MonsterRaceFiltersEnum.CthuloidMonsterRaceFilter);
    public override string[]? DungeonGuardianNames => new string[]
    {
        nameof(NyarlathotepDungeonGuardian),
        nameof(AzathothTheDaemonSultanDungeonGuardian)
    };
    public override string Name => "the Catacombs under Kadath";
    public override string Shortname => "Kadath";
    public override string MapSymbol => "K";
}