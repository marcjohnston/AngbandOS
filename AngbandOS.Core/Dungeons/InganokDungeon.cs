// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class InganokDungeon : Dungeon
{
    private InganokDungeon(Game game) : base(game) { }
    public override int BaseOffset => 0;
    public override int MaxLevel => 5;
    public override string Name => "the Sewers under Inganok";
    public override string Shortname => "Inganok";
    public override string MapSymbol => "I";
}