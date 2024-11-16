// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class GreatOldOneSummonMonsterSpell : SummonMonsterSpell
{
    private GreatOldOneSummonMonsterSpell(Game game) : base(game) { }
    protected override int MaximumSummonCount => 8;
    protected override string? MonsterSelectorKey => nameof(GooMonsterFilter);
    public override string? VsPlayerActionMessage => "{0} magically summons Great Old Ones!";
}
