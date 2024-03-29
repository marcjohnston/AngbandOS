// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SpectreMonsterRace : MonsterRace
{
    protected SpectreMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ForgetMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperGSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 30;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(WailAttack), nameof(TerrifyAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(Exp40AttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(LoseWisAttackEffect), 5, 5),
    };
    public override bool ColdBlood => true;
    public override string Description => "A phantasmal shrieking spirit. Its wail drives the intense cold of pure evil deep within your body.";
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Spectre";
    public override int Hdice => 14;
    public override int Hside => 20;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 33;
    public override int Mexp => 350;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Spectre";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
