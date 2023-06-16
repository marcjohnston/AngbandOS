namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KillerCrimsonBeetleMonsterRace : MonsterRace
{
    protected KillerCrimsonBeetleMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'K';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Killer crimson beetle";

    public override bool Animal => true;
    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new LoseStrAttackEffect(), 4, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A giant beetle with poisonous mandibles.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Killer crimson beetle";
    public override int Hdice => 20;
    public override int Hside => 8;
    public override int LevelFound => 25;
    public override int Mexp => 85;
    public override int NoticeRange => 14;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "   Killer   ";
    public override string SplitName2 => "  crimson   ";
    public override string SplitName3 => "   beetle   ";
    public override bool WeirdMind => true;
}
