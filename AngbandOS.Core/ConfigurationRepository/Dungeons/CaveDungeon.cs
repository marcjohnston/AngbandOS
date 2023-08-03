// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class CaveDungeon : Dungeon
{
    private CaveDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 30;
    public override int MaxLevel => 20;
    public override string FirstGuardian => "The Collector";
    public override int FirstLevel => 20;
    public override string Name => "the Collector's Cave";
    public override string Shortname => "Cave";
    public override string MapSymbol => "c";
}