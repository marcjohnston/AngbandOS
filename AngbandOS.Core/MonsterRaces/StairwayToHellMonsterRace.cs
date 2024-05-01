// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class StairwayToHellMonsterRace : MonsterRace
{
    protected StairwayToHellMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ShriekMonsterSpell),
        nameof(SummonDemonMonsterSpell)
    };

    protected override string SymbolName => nameof(GreaterThanSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 40;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(WailAttack), nameof(DisenchantAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(WailAttack), nameof(Exp20AttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(WailAttack), nameof(EatGoldAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(WailAttack), nameof(EatItemAttackEffect), 0, 0)
    };
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "Often found in graveyards.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Stairway to hell";
    public override int Hdice => 15;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 28;
    public override int Mexp => 125;
    public override bool NeverMove => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 90;
    public override int Rarity => 5;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Stairway\nto\nhell";
    public override bool Undead => true;
}
