namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MemoryMossMonsterRace : MonsterRace
{
    protected MemoryMossMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new ForgetMonsterSpell());
    public override char Character => ',';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Memory moss";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 1, 4),
        new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 1, 4),
    };
    public override string Description => "A mass of green vegetation. You don't remember seeing anything like it before.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Memory moss";
    public override int Hdice => 1;
    public override int Hside => 2;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 32;
    public override int Mexp => 150;
    public override bool NeverMove => true;
    public override int NoticeRange => 30;
    public override int Rarity => 3;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Memory   ";
    public override string SplitName3 => "    moss    ";
    public override bool Stupid => true;
}
