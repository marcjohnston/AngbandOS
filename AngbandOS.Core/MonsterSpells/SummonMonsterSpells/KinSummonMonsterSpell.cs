// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class KinSummonMonsterSpell : SummonMonsterSpell
{
    public override string? VsPlayerActionMessage => "{0} magically summons {1} {2}!";

    private KinSummonMonsterSpell(Game game) : base(game) { }

    /// <summary>
    /// Returns a kin monster selector with the character of the original monster for summoning.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected override string? MonsterSelectorBindingKey => nameof(KinMonsterSelector);
}
