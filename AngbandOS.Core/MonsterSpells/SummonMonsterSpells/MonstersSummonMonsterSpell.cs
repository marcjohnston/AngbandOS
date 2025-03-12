// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class MonstersSummonMonsterSpell : SummonMonsterSpell
{
    private MonstersSummonMonsterSpell(Game game) : base(game) { }
    public override string? VsPlayerActionMessage => "{0} magically summons monsters!";

    /// <summary>
    /// Returns 8, to summon upto 8 monsters.
    /// </summary>
    protected override int MaximumSummonCount => 8;

    /// <summary>
    /// Returns null, for any monster to be summoned.
    /// </summary>
    protected override string? MonsterSelectorKey => null;

    protected override string? FriendlyMonsterSelectorKey => nameof(NoUniquesMonsterRaceFilter);
}
