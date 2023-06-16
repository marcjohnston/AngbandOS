namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PseudoDragonMonsterRace : MonsterRace
{
    protected PseudoDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheDarkMonsterSpell(),
        new BreatheLightMonsterSpell(),
        new ConfuseMonsterSpell(),
        new ScareMonsterSpell());
    public override char Character => 'd';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "Pseudo dragon";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A small relative of the dragon that inhabits dark caves.";
    public override bool Dragon => true;
    public override bool Drop60 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Pseudo dragon";
    public override int Hdice => 20;
    public override int Hside => 10;
    public override int LevelFound => 10;
    public override int Mexp => 150;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Pseudo   ";
    public override string SplitName3 => "   dragon   ";
}
