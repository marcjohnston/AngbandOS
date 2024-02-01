// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class TowerDungeon : Dungeon
{
    private TowerDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 13;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 17;
    public override MonsterFilter? Bias => SaveGame.SingletonRepository.MonsterFilters.Get(nameof(SpiderMonsterFilter));
    public override string FirstGuardian => "Shelob, Spider of Darkness";
    public override int FirstLevel => 17;
    public override string Name => "Shelob's Tower";
    public override string Shortname => "Tower";
    public override string MapSymbol => "s";
}