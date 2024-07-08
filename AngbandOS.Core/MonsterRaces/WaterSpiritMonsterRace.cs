// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WaterSpiritMonsterRace : MonsterRace
{
    protected WaterSpiritMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperESymbol);
    public override ColorEnum Color => ColorEnum.Turquoise;
    
    public override int ArmorClass => 28;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 4),
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 4),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A whirlpool of sentient liquid.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Water spirit";
    public override int Hdice => 9;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 17;
    public override int Mexp => 58;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 120;
    public override string? MultilineName => "Water\nspirit";
}
