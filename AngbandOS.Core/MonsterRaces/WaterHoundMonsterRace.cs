namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WaterHoundMonsterRace : MonsterRace
{
    protected WaterHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheAcidMonsterSpell());
    public override char Character => 'Z';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Water hound";

    public override bool Animal => true;
    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new AcidAttackEffect(), 2, 8),
        new MonsterAttack(new BiteAttackType(), new AcidAttackEffect(), 2, 8),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 3, 3),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 3, 3)
    };
    public override bool BashDoor => true;
    public override string Description => "Liquid footprints follow this hound as it pads around the dungeon. An acrid smell of acid rises from the dog's pelt.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Water hound";
    public override bool Friends => true;
    public override int Hdice => 15;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 20;
    public override int Mexp => 200;
    public override int NoticeRange => 30;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Water    ";
    public override string SplitName3 => "   hound    ";
}
