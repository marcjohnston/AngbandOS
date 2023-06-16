namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WaterSpiritMonsterRace : MonsterRace
{
    protected WaterSpiritMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'E';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "Water spirit";

    public override int ArmourClass => 28;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 4),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 4),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A whirlpool of sentient liquid.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Water spirit";
    public override int Hdice => 9;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 17;
    public override int Mexp => 58;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Water    ";
    public override string SplitName3 => "   spirit   ";
}
