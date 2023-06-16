namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AirSpiritMonsterRace : MonsterRace
{
    protected AirSpiritMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'E';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Air spirit";

    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 3),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A whirlwind of sentient air.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Air spirit";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 12;
    public override int Mexp => 40;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Air     ";
    public override string SplitName3 => "   spirit   ";
}
