// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class SpireDungeon : Dungeon
{
    private SpireDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 15;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 20;
    public override MonsterSelector? Bias => new DemonMonsterSelector();
    public override string FirstGuardian => "The Emissary";
    public override string SecondGuardian => "Glaryssa, Succubus Queen";
    public override int FirstLevel => 1;
    public override int SecondLevel => 20;
    public override string Name => "the Demon Spire";
    public override string Shortname => "Spire";
    public override string MapSymbol => "d";
}