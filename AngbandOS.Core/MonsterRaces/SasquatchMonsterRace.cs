namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SasquatchMonsterRace : MonsterRace
{
    protected SasquatchMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'Y';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Sasquatch";

    public override bool Animal => true;
    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 10),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 10),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A tall shaggy, furry humanoid, it could call the yeti brother.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Sasquatch";
    public override int Hdice => 20;
    public override int Hside => 19;
    public override bool ImmuneCold => true;
    public override int LevelFound => 20;
    public override int Mexp => 180;
    public override int NoticeRange => 15;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Sasquatch  ";
}
