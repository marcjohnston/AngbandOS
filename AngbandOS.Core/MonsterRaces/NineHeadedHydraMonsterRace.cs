namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NineHeadedHydraMonsterRace : MonsterRace
{
    protected NineHeadedHydraMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheFireMonsterSpell(),
        new FireBoltMonsterSpell(),
        new ScareMonsterSpell());
    public override char Character => 'M';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "9-headed hydra";

    public override bool Animal => true;
    public override int ArmourClass => 95;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 3, 6),
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 3, 6),
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 3, 6),
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 3, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A strange reptilian hybrid with nine smouldering heads.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "9-headed hydra";
    public override int Hdice => 100;
    public override int Hside => 12;
    public override bool ImmuneFire => true;
    public override int LevelFound => 40;
    public override int Mexp => 3000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  9-headed  ";
    public override string SplitName3 => "   hydra    ";
}
