namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HalflingSlingerMonsterRace : MonsterRace
{
    protected HalflingSlingerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new Arrow7D6MonsterSpell());
    public override char Character => 'h';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Halfling slinger";

    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6),
    };
    public override string Description => "A rebel halfling who has rejected the halfling tradition of archery.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Halfling slinger";
    public override bool Friends => true;
    public override int Hdice => 30;
    public override int Hside => 9;
    public override bool ImmuneCold => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 35;
    public override bool Male => true;
    public override int Mexp => 330;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Halfling  ";
    public override string SplitName3 => "  slinger   ";
}
