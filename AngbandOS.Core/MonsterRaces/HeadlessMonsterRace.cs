namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HeadlessMonsterRace : MonsterRace
{
    protected HeadlessMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new ScareMonsterSpell());
    public override char Character => 'H';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Headless";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "Headless humanoid abominations created by a magical mutation.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Headless";
    public override bool Friends => true;
    public override int Hdice => 21;
    public override int Hside => 12;
    public override int LevelFound => 27;
    public override int Mexp => 175;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Headless  ";
}
