namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WildCatMonsterRace : MonsterRace
{
    protected WildCatMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'f';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Wild cat";

    public override bool Animal => true;
    public override int ArmourClass => 12;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "A larger than normal feline, hissing loudly. Its velvet claws conceal a fistful of needles.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Wild cat";
    public override int Hdice => 3;
    public override int Hside => 5;
    public override int LevelFound => 2;
    public override int Mexp => 8;
    public override int NoticeRange => 40;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Wild    ";
    public override string SplitName3 => "    cat     ";
}
