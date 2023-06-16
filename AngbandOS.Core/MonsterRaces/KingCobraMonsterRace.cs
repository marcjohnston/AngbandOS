namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KingCobraMonsterRace : MonsterRace
{
    protected KingCobraMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'J';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "King cobra";

    public override bool Animal => true;
    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new SpitAttackType(), new BlindAttackEffect(), 1, 2),
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 3, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a large snake with a hooded face.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "King cobra";
    public override int Hdice => 8;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 9;
    public override int Mexp => 28;
    public override int NoticeRange => 8;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 1;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    King    ";
    public override string SplitName3 => "   cobra    ";
}
