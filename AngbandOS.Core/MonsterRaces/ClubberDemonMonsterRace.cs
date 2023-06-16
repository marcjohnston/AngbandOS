namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ClubberDemonMonsterRace : MonsterRace
{
    protected ClubberDemonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BlindnessMonsterSpell(),
        new ConfuseMonsterSpell());
    public override char Character => 'U';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Clubber demon";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 4),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 8, 12),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 8, 12),
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "It is a demon swinging wildly with two clubs. Not even remotely subtle.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Clubber demon";
    public override bool Friends => true;
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 40;
    public override int Mexp => 1000;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Clubber   ";
    public override string SplitName3 => "   demon    ";
}
