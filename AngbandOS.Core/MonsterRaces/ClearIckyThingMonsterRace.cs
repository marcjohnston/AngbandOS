namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ClearIckyThingMonsterRace : MonsterRace
{
    protected ClearIckyThingMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'i';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Clear icky thing";

    public override int ArmourClass => 6;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new HurtAttackEffect(), 1, 2),
    };
    public override bool AttrClear => true;
    public override string Description => "It is a smallish, slimy, icky, blobby creature.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Clear icky thing";
    public override int Hdice => 2;
    public override int Hside => 5;
    public override bool Invisible => true;
    public override int LevelFound => 1;
    public override int Mexp => 1;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "   Clear    ";
    public override string SplitName2 => "    icky    ";
    public override string SplitName3 => "   thing    ";
}
