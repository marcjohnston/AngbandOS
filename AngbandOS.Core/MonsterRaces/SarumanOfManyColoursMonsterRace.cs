namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SarumanOfManyColoursMonsterRace : MonsterRace
{
    protected SarumanOfManyColoursMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new AcidBallMonsterSpell(),
        new BlindnessMonsterSpell(),
        new CauseMortalWoundsMonsterSpell(),
        new ColdBallMonsterSpell(),
        new ConfuseMonsterSpell(),
        new FireBallMonsterSpell(),
        new IceBoltMonsterSpell(),
        new MindBlastMonsterSpell(),
        new ScareMonsterSpell(),
        new WaterBallMonsterSpell(),
        new CreateTrapsMonsterSpell(),
        new ForgetMonsterSpell(),
        new HasteMonsterSpell(),
        new HealMonsterSpell(),
        new SummonDemonMonsterSpell(),
        new SummonDragonMonsterSpell(),
        new SummonUndeadMonsterSpell(),
        new TeleportAwayMonsterSpell(),
        new TeleportSelfMonsterSpell());
    public override char Character => 'p';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Saruman of Many Colours";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 6, 8),
        new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 6, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "Originally known as the White, Saruman fell prey to Sauron's wiles. He searches forever for the One Ring, to become a mighty Sorcerer-King of the world.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Saruman of Many Colours";
    public override int Hdice => 50;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 60;
    public override bool Male => true;
    public override int Mexp => 35000;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "  Saruman   ";
    public override string SplitName2 => "  of Many   ";
    public override string SplitName3 => "  Colours   ";
    public override bool Unique => true;
}
