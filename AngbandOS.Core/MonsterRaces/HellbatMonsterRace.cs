namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HellbatMonsterRace : MonsterRace
{
    protected HellbatMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'b';
    public override Colour Colour => Colour.Red;
    public override string Name => "Hellbat";

    public override bool Animal => true;
    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 1, 8),
    };
    public override string Description => "Devil-bats, notoriously difficult to kill.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Hellbat";
    public override bool Friends => true;
    public override int Hdice => 12;
    public override int Hside => 12;
    public override bool ImmuneCold => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 13;
    public override int Mexp => 65;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 8;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Hellbat   ";
    public override bool WeirdMind => true;
}
