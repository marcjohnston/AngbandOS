// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class KadathDungeon : Dungeon
{
    private KadathDungeon(Game game) : base(game) { }
    public override int BaseOffset => 50;
    public override int MaxLevel => 75;
    protected override string? BiasMonsterFilterName => nameof(CthuloidMonsterFilter);
    protected override string[]? DungeonGuardianNames => new string[]
    {
        nameof(NyarlathotepDungeonGuardian),
        nameof(AzathothTheDaemonSultanDungeonGuardian)
    };
    public override string Name => "the Catacombs under Kadath";
    public override string Shortname => "Kadath";
    public override string MapSymbol => "K";
}