namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NoviceWarriorMonsterRace : MonsterRace
{
    protected NoviceWarriorMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'p';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Novice warrior";

    public override int ArmourClass => 16;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 7),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "He looks inexperienced but tough.";
    public override bool Drop60 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Novice warrior";
    public override int Hdice => 9;
    public override int Hside => 4;
    public override int LevelFound => 2;
    public override bool Male => true;
    public override int Mexp => 6;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Novice   ";
    public override string SplitName3 => "  warrior   ";
}
