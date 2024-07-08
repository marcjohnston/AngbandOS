// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HobbesTheTigerMonsterRace : MonsterRace
{
    protected HobbesTheTigerMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerFSymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 11),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 11),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "Fast-moving, with a taste for tuna sandwiches.";
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Hobbes the Tiger";
    public override int Hdice => 10;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 10;
    public override bool Male => true;
    public override int Mexp => 45;
    public override int NoticeRange => 40;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Hobbes\nthe\nTiger";
    public override bool Unique => true;
}
