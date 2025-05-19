// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NecropolisDungeon : DungeonGameConfiguration
{
    public override int BaseOffset => 30;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 40;
    public override string? BiasMonsterFilterName => nameof(MonsterRaceFiltersEnum.HiUndeadMonsterRaceFilter);
    public override string[]? DungeonGuardianNames => new string[]
    {
        nameof(FirePhantomDungeonGuardian),
        nameof(VecnaTheEmperorLichDungeonGuardian)
    };
    public override string Name => "the Necropolis";
    public override string Shortname => "Necropolis";
    public override string MapSymbol => "n";
}