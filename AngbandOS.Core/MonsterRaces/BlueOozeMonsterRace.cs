namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlueOozeMonsterRace : MonsterRace
{
    protected BlueOozeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'j';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Blue ooze";

    public override int ArmourClass => 16;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrawlAttackType(), new ColdAttackEffect(), 1, 4),
    };
    public override string Description => "It's blue and it's oozing.";
    public override bool Drop60 => true;
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Blue ooze";
    public override int Hdice => 3;
    public override int Hside => 4;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 5;
    public override int Mexp => 7;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Blue    ";
    public override string SplitName3 => "    ooze    ";
    public override bool Stupid => true;
}
