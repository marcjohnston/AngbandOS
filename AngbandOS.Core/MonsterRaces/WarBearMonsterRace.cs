namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WarBearMonsterRace : MonsterRace
{
    protected WarBearMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'q';
    public override Colour Colour => Colour.Brown;
    public override string Name => "War bear";

    public override bool Animal => true;
    public override int ArmourClass => 35;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "Bears with tusks, trained to kill.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "War bear";
    public override bool Friends => true;
    public override int Hdice => 10;
    public override int Hside => 10;
    public override int LevelFound => 9;
    public override int Mexp => 25;
    public override int NoticeRange => 10;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    War     ";
    public override string SplitName3 => "    bear    ";
    public override bool WeirdMind => true;
}
