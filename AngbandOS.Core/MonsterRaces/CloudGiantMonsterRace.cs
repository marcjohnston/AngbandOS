namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CloudGiantMonsterRace : MonsterRace
{
    protected CloudGiantMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'P';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Cloud giant";

    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new ElectricityAttackEffect(), 3, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a twenty foot tall giant wreathed in clouds.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Cloud giant";
    public override bool Giant => true;
    public override int Hdice => 24;
    public override int Hside => 10;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 20;
    public override bool Male => true;
    public override int Mexp => 125;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Cloud    ";
    public override string SplitName3 => "   giant    ";
    public override bool TakeItem => true;
}
