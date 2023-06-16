namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantFleaMonsterRace : MonsterRace
{
    protected GiantFleaMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'I';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Giant flea";

    public override bool Animal => true;
    public override int ArmourClass => 7;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 2),
    };
    public override string Description => "It makes you itch just to look at it. ";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant flea";
    public override int Hdice => 1;
    public override int Hside => 2;
    public override int LevelFound => 14;
    public override int Mexp => 3;
    public override bool Multiply => true;
    public override int NoticeRange => 6;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Giant    ";
    public override string SplitName3 => "    flea    ";
    public override bool WeirdMind => true;
}
