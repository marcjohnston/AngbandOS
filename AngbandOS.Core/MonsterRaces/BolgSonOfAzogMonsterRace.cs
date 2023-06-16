namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BolgSonOfAzogMonsterRace : MonsterRace
{
    protected BolgSonOfAzogMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'o';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Bolg, Son of Azog";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A large and powerful orc. He looks just like his daddy. He is tall and fast, but fortunately blessed with orcish brains.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Bolg, Son of Azog";
    public override int Hdice => 50;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 20;
    public override bool Male => true;
    public override int Mexp => 800;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 4;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "    Bolg    ";
    public override bool Unique => true;
}
