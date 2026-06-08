// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonstersSummonMonsterSpell : SummonMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "summon monsters");
    public override string? VsPlayerActionMessage => "{0} magically summons monsters!";

    /// <summary>
    /// Returns 8, to summon up to 8 monsters.
    /// </summary>
    public override string MaximumSummonCountExpressionText => "8";

    /// <summary>
    /// Returns null, for any monster to be summoned.
    /// </summary>
    public override string? MonsterSelectorBindingKey => null;

    public override string? FriendlyMonsterSelectorBindingKey => nameof(MonsterRaceFiltersEnum.NoUniquesMonsterRaceFilter);
}
