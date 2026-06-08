// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ReaverSummonMonsterSpell : SummonMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "summon Black Reavers");
    public override string? VsPlayerActionMessage => "{0} magically summons Black Reavers!";

    public override string MaximumSummonCountExpressionText => "f/50 + 1d6";

    public override int? SummonLevel => 100;

    /// <summary>
    /// Returns null, because the Execute methods are overridden because Reavers can only be summoned via the SummonReaver method.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    public override string? MonsterSelectorBindingKey => nameof(MonsterRaceFiltersEnum.ReaverMonsterRaceFilter);
}
