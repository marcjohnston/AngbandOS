// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonsterSummonMonsterSpell : SummonMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "summon a monster");
    public override string? VsPlayerActionMessage => "{0} magically summons help!";

    /// <summary>
    /// Returns null, to summon any monster.
    /// </summary>
    public override string? MonsterSelectorBindingKey => null;

    /// <summary>
    /// Returns 1, to summon a single monster.
    /// </summary>
    public override string MaximumSummonCountExpressionText => "1";
}
