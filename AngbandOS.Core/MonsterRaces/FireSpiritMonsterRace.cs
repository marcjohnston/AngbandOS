// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FireSpiritMonsterRace : MonsterRace
{
    protected FireSpiritMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperESymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override int ArmorClass => 30;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(FireAttackEffect), 2, 6),
        (nameof(HitAttack), nameof(FireAttackEffect), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A whirlwind of sentient flame.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Fire spirit";
    public override int Hdice => 10;
    public override int Hside => 9;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 18;
    public override int Mexp => 75;
    public override int NoticeRange => 16;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Fire\nspirit";
}
