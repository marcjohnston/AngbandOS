namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PlayerMonsterRace : MonsterRace
{
    protected PlayerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => '@';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Player";

    public override int ArmourClass => 0;
    public override MonsterAttack[]? Attacks => null;
    public override string Description => "You";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Player";
    public override int Hdice => 0;
    public override int Hside => 0;
    public override int LevelFound => -1;
    public override int Mexp => 0;
    public override int NoticeRange => 0;
    public override int Rarity => 0;
    public override int Sleep => 0;
    public override int Speed => 0;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Player   ";
}
