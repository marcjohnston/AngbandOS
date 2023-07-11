// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class HlanithDungeon : Dungeon
{
    private HlanithDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 0;
    public override int MaxLevel => 5;
    public override string Name => "the Sewers under Hlanith";
    public override string Shortname => "Hlanith";
    public override string MapSymbol => "H";
}