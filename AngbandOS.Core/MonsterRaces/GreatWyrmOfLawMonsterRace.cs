// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatWyrmOfLawMonsterRace : MonsterRace
{
    protected GreatWyrmOfLawMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheShardsMonsterSpell),
        nameof(BreatheSoundMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonDragonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Silver;
    
    public override int ArmorClass => 170;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 8, 14)
    };
    public override bool BashDoor => true;
    public override string Description => "A massive dragon of powerful intellect. It seeks to dominate the universe and despises all other life. It sees all who do not obey it as mere insects to be crushed underfoot.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Great Wyrm of Law";
    public override bool Good => true;
    public override int Hdice => 45;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 67;
    public override int Mexp => 29000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 255;
    public override int Speed => 120;
    public override string? MultilineName => "Great\nWyrm of\nLaw";
}
