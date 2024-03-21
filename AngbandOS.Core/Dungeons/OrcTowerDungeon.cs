// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class OrcTowerDungeon : Dungeon
{
    private OrcTowerDungeon(Game game) : base(game) { }
    public override int BaseOffset => 3;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 17;
    protected override string? BiasMonsterFilterName => nameof(OrcMonsterFilter);
    protected override string[]? DungeonGuardianNames => new string[]
    {
        nameof(BolgSonOfAzogDungeonGuardian),
        nameof(AzogKingOfTheUrukHaiDungeonGuardian)
    };
    public override string Name => "the Orc Tower";
    public override string Shortname => "Orc Tower";
    public override string MapSymbol => "o";
}