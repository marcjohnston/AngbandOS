namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KlingsorEvilMasterOfMagicMonsterRace : MonsterRace
{
    protected KlingsorEvilMasterOfMagicMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new ChaosBallMonsterSpell(),
        new CauseCriticalWoundsMonsterSpell(),
        new DarkBallMonsterSpell(),
        new DrainManaMonsterSpell(),
        new FireBallMonsterSpell(),
        new HoldMonsterSpell(),
        new ManaBallMonsterSpell(),
        new NetherBallMonsterSpell(),
        new PlasmaBoltMonsterSpell(),
        new WaterBallMonsterSpell(),
        new CreateTrapsMonsterSpell(),
        new DreadCurseMonsterSpell(),
        new SummonHiUndeadMonsterSpell(),
        new TeleportToMonsterSpell());
    public override char Character => 'p';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Klingsor, Evil Master of Magic";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 6, 8),
        new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 6, 8),
        new MonsterAttack(new TouchAttackType(), new UnPowerAttackEffect(), 0, 0),
        new MonsterAttack(new TouchAttackType(), new UnPowerAttackEffect(), 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "Klingsor, whose hopeless effort to join the Knights of the Grail was thwarted, turned to black magic and became a deadly necromancer.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Klingsor, Evil Master of Magic";
    public override int Hdice => 70;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 78;
    public override bool Male => true;
    public override int Mexp => 40000;
    public override int NoticeRange => 60;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Klingsor  ";
    public override bool Unique => true;
}
