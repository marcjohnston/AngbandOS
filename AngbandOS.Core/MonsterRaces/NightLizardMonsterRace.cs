namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NightLizardMonsterRace : MonsterRace
{
    protected NightLizardMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'R';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Night lizard";

    public override bool Animal => true;
    public override int ArmourClass => 16;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
    };
    public override string Description => "It is a black lizard with overlapping scales and a powerful jaw.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Night lizard";
    public override int Hdice => 4;
    public override int Hside => 8;
    public override int LevelFound => 7;
    public override int Mexp => 35;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Night    ";
    public override string SplitName3 => "   lizard   ";
}
