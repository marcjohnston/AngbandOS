// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HuntingHawkMonsterRace : MonsterRace
{
    protected HuntingHawkMonsterRace(Game game) : base(game) { }


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperBSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override bool Animal => true;
    public override int ArmorClass => 25;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 3),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 3),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 4),
    };
    public override string Description => "Trained to hunt and kill without fear.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Hunting hawk";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool ImmuneFear => true;
    public override int LevelFound => 8;
    public override int Mexp => 22;
    public override int NoticeRange => 30;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Hunting\nhawk";
}
