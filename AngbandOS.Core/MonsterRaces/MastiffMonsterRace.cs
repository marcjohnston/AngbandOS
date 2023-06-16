namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MastiffMonsterRace : MonsterRace
{
    protected MastiffMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'C';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Mastiff";

    public override bool Animal => true;
    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 5),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 5),
    };
    public override string Description => "Well-trained watchdogs, obedient to death.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Mastiff";
    public override bool Friends => true;
    public override int Hdice => 8;
    public override int Hside => 9;
    public override bool ImmuneFear => true;
    public override int LevelFound => 14;
    public override int Mexp => 40;
    public override int NoticeRange => 8;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Mastiff   ";
}
