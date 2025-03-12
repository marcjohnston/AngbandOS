// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ReaverSummonMonsterSpell : SummonMonsterSpell
{
    private ReaverSummonMonsterSpell(Game game) : base(game) { }
    public override string? VsPlayerActionMessage => "{0} magically summons Black Reavers!";

    protected override int MaximumSummonCount => (Game.Difficulty / 50) + Game.DieRoll(6);

    protected override int? SummonLevel => 100;

    /// <summary>
    /// Returns null, because the Execute methods are overridden because Reavers can only be summoned via the SummonReaver method.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected override string? MonsterSelectorKey => nameof(ReaverMonsterRaceFilter);
}
