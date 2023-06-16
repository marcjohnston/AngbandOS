namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlueWormMassMonsterRace : MonsterRace
{
    protected BlueWormMassMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'w';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Blue worm mass";

    public override bool Animal => true;
    public override int ArmourClass => 12;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrawlAttackType(), new ColdAttackEffect(), 1, 4),
    };
    public override bool ColdBlood => true;
    public override string Description => "It is a large slimy mass of worms.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Blue worm mass";
    public override int Hdice => 5;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 4;
    public override int Mexp => 5;
    public override bool Multiply => true;
    public override int NoticeRange => 7;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "    Blue    ";
    public override string SplitName2 => "    worm    ";
    public override string SplitName3 => "    mass    ";
    public override bool Stupid => true;
    public override bool WeirdMind => true;
}
