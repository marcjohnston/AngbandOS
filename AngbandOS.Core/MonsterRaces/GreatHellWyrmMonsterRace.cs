namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatHellWyrmMonsterRace : MonsterRace
{
    protected GreatHellWyrmMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheFireMonsterSpell(),
        new BlindnessMonsterSpell(),
        new ConfuseMonsterSpell(),
        new ScareMonsterSpell());
    public override char Character => 'D';
    public override Colour Colour => Colour.Red;
    public override string Name => "Great hell wyrm";

    public override int ArmourClass => 170;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 12),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 12),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 12),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 5, 14)
    };
    public override bool BashDoor => true;
    public override string Description => "A vast dragon of immense power. Fire leaps continuously from its huge form. The air around it scalds you. Its slightest glance burns you, and you truly realize how insignificant you are.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Great hell wyrm";
    public override int Hdice => 54;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 55;
    public override int Mexp => 23000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 40;
    public override int Speed => 120;
    public override string SplitName1 => "   Great    ";
    public override string SplitName2 => "    hell    ";
    public override string SplitName3 => "    wyrm    ";
}
