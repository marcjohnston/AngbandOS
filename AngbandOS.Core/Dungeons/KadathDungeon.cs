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
    private KadathDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 50;
    public override int MaxLevel => 75;
    public override MonsterSelector? Bias => new CthuloidMonsterSelector();
    public override string FirstGuardian => "Nyarlathotep";
    public override string SecondGuardian => "Azathoth, The Daemon Sultan";
    public override int FirstLevel => 49;
    public override int SecondLevel => 50;
    public override string Name => "the Catacombs under Kadath";
    public override string Shortname => "Kadath";
    public override string MapSymbol => "K";
}