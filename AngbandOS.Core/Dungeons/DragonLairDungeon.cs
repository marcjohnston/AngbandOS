// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class DragonLairDungeon : Dungeon
{
    private DragonLairDungeon(Game game) : base(game) { }
    public override int BaseOffset => 15;
    public override int MaxLevel => 35;
    protected override string? BiasMonsterFilterName => nameof(DragonMonsterRaceFilter);
    protected override string[]? DungeonGuardianNames => new string[]
    {
        nameof(GlaurungFatherOfTheDragonsDungeonGuardian),
        nameof(AncalagonTheBlackDungeonGuardian)
    };
    public override string Name => "the Dragon's Lair";
    public override string Shortname => "Dragon Lair";
    public override string MapSymbol => "l";
}