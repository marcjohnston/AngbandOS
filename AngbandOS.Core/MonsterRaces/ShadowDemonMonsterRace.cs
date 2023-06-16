namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShadowDemonMonsterRace : MonsterRace
{
    protected ShadowDemonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new NetherBoltMonsterSpell());
    public override char Character => 'G';
    public override Colour Colour => Colour.Black;
    public override string Name => "Shadow demon";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new Exp80AttackEffect(), 0, 0),
        new MonsterAttack(new TouchAttackType(), new Exp40AttackEffect(), 0, 0),
        new MonsterAttack(new ClawAttackType(), new LoseIntAttackEffect(), 1, 10),
        new MonsterAttack(new ClawAttackType(), new LoseWisAttackEffect(), 1, 10)
    };
    public override bool ColdBlood => true;
    public override bool Demon => true;
    public override string Description => "A mighty spirit of darkness of vaguely humanoid form. Razor-edged claws reach out to end your life as it glides towards you, seeking to suck the energy from your soul to feed its power.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Shadow demon";
    public override bool Friends => true;
    public override int Hdice => 10;
    public override int Hside => 20;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 42;
    public override int Mexp => 425;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override bool ResistNether => true;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Shadow   ";
    public override string SplitName3 => "   demon    ";
    public override bool Undead => true;
}
