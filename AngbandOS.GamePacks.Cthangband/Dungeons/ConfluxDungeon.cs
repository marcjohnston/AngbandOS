// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ConfluxDungeon : DungeonGameConfiguration
{
    public override int BaseOffset => 20;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 20;
    public override string? BiasMonsterFilterName => nameof(MonsterRaceFiltersEnum.ElementalMonsterRaceFilter);
    public override string[]? DungeonGuardianNames => new string[]
    {
        nameof(LashaMistressOfWaterDungeonGuardian),
        nameof(GromMasterOfEarthDungeonGuardian)
    };
    public override string Name => "the Conflux of the Elements";
    public override string Shortname => "Conflux";
    public override string MapSymbol => "e";
}