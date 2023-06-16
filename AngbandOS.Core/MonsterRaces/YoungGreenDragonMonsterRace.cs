namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class YoungGreenDragonMonsterRace : MonsterRace
{
    protected YoungGreenDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreathePoisonMonsterSpell(),
        new ScareMonsterSpell());
    public override char Character => 'd';
    public override Colour Colour => Colour.Green;
    public override string Name => "Young green dragon";

    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It has a form that legends are made of. Its still-tender scales are a deep green in hue. Foul gas seeps through its scales.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Young green dragon";
    public override int Hdice => 27;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 29;
    public override int Mexp => 290;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string SplitName1 => "   Young    ";
    public override string SplitName2 => "   green    ";
    public override string SplitName3 => "   dragon   ";
}
