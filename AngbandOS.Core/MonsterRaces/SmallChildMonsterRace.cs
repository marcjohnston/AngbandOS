namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SmallChildMonsterRace : MonsterRace
{
    protected SmallChildMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 't';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Small child";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new WorshipAttackType(), null, 0, 0),
    };
    public override string Description => "A rather cute child with large trusting eyes.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Small child";
    public override bool Friends => true;
    public override int Hdice => 1;
    public override int Hside => 2;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 6;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Small    ";
    public override string SplitName3 => "   child    ";
}
