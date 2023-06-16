namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MinotaurMonsterRace : MonsterRace
{
    protected MinotaurMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'H';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Minotaur";

    public override int ArmourClass => 25;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ButtAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new ButtAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a cross between a human and a bull.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Minotaur";
    public override int Hdice => 100;
    public override int Hside => 10;
    public override int LevelFound => 40;
    public override int Mexp => 2100;
    public override int NoticeRange => 13;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Minotaur  ";
}
