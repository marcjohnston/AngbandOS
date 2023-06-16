namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class EtherealDrakeMonsterRace : MonsterRace
{
    protected EtherealDrakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheDarkMonsterSpell(),
        new BreatheLightMonsterSpell(),
        new ConfuseMonsterSpell(),
        new ScareMonsterSpell(),
        new SlowMonsterSpell());
    public override char Character => 'd';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "Ethereal drake";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 8),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 8),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
    };
    public override string Description => "A dragon of elemental power, with control over light and dark, the ethereal drake's eyes glare with white hatred from the shadows.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Ethereal drake";
    public override int Hdice => 45;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 33;
    public override int Mexp => 700;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override int Rarity => 3;
    public override int Sleep => 15;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Ethereal  ";
    public override string SplitName3 => "   drake    ";
}
