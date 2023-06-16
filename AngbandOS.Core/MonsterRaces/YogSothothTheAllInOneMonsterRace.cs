namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class YogSothothTheAllInOneMonsterRace : MonsterRace
{
    protected YogSothothTheAllInOneMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheDisintegrationMonsterSpell(),
        new BreatheManaMonsterSpell(),
        new ChaosBallMonsterSpell(),
        new BrainSmashMonsterSpell(),
        new ManaBallMonsterSpell(),
        new ManaBoltMonsterSpell(),
        new SummonCthuloidMonsterSpell(),
        new SummonHiUndeadMonsterSpell(),
        new SummonHoundMonsterSpell(),
        new SummonMonstersMonsterSpell(),
        new SummonReaverMonsterSpell());
    public override char Character => 'X';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Yog-Sothoth, the All-in-One";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new HurtAttackEffect(), 40, 5),
        new MonsterAttack(new TouchAttackType(), new LoseConAttackEffect(), 16, 2),
        new MonsterAttack(new TouchAttackType(), new LoseConAttackEffect(), 16, 2),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "An outer god whose form resembles a mass of great floating globes.";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Yog-Sothoth, the All-in-One";
    public override bool GreatOldOne => true;
    public override int Hdice => 66;
    public override int Hside => 99;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 90;
    public override bool LightningAura => true;
    public override int Mexp => 45000;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool PassWall => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Yog-Sothoth ";
    public override bool Unique => true;
}
