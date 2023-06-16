namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WaterElementalMonsterRace : MonsterRace
{
    protected WaterElementalMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new ColdBoltMonsterSpell());
    public override char Character => 'E';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Water elemental";

    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a towering tempest of water.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Water elemental";
    public override int Hdice => 25;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 33;
    public override int Mexp => 325;
    public override int NoticeRange => 12;
    public override bool Powerful => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Water    ";
    public override string SplitName3 => " elemental  ";
}
