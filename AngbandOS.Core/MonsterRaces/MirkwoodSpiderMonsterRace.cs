namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MirkwoodSpiderMonsterRace : MonsterRace
{
    protected MirkwoodSpiderMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'S';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Mirkwood spider";

    public override bool Animal => true;
    public override int ArmourClass => 25;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 8),
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 1, 6),
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A strong and powerful spider from Mirkwood forest. Cunning and evil, it seeks to taste your juicy insides.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Mirkwood spider";
    public override bool Friends => true;
    public override int Hdice => 9;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 15;
    public override int Mexp => 25;
    public override int NoticeRange => 15;
    public override int Rarity => 2;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Mirkwood  ";
    public override string SplitName3 => "   spider   ";
    public override bool WeirdMind => true;
}
