namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class IllusionistMonsterRace : MonsterRace
{
    protected IllusionistMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BlindnessMonsterSpell(),
        new ConfuseMonsterSpell(),
        new HoldMonsterSpell(),
        new SlowMonsterSpell(),
        new BlinkMonsterSpell(),
        new DarknessMonsterSpell(),
        new HasteMonsterSpell(),
        new TeleportSelfMonsterSpell());
    public override char Character => 'p';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Illusionist";

    public override int ArmourClass => 10;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 2),
    };
    public override bool BashDoor => true;
    public override string Description => "A deceptive spell caster.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Illusionist";
    public override int Hdice => 12;
    public override int Hside => 8;
    public override int LevelFound => 13;
    public override bool Male => true;
    public override int Mexp => 50;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Illusionist ";
}
