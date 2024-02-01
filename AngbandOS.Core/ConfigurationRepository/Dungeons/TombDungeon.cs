// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class TombDungeon : Dungeon
{
    private TombDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 4;
    public override int MaxLevel => 21;
    protected override string? BiasMonsterFilterName => nameof(UndeadMonsterFilter);
    protected override string[]? DungeonGuardianNames => new string[]
    {
        nameof(TheDisembodiedHandDungeonGuardian),
        nameof(KhufuTheMummifiedKingDungeonGuardian)
    };
    public override string Name => "Khufu's Tomb";
    public override string Shortname => "Tomb";
    public override string MapSymbol => "t";
}