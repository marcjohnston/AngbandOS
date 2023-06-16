namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CreepingSilverCoinsMonsterRace : MonsterRace
{
    protected CreepingSilverCoinsMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => '$';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Creeping silver coins";

    public override bool Animal => true;
    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 6),
        new MonsterAttack(new TouchAttackType(), new PoisonAttackEffect(), 2, 6),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a pile of coins, crawling forward on thousands of tiny legs.";
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Creeping silver coins";
    public override int Hdice => 12;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 6;
    public override int Mexp => 18;
    public override int NoticeRange => 4;
    public override bool OnlyDropGold => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "  Creeping  ";
    public override string SplitName2 => "   silver   ";
    public override string SplitName3 => "   coins    ";
}
