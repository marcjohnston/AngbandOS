// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HiUndeadSummonMonsterSpell : SummonMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "summon Greater Undead");
    public override string? VsPlayerActionMessage => "{0} magically summons greater undead!";
    public override string MaximumSummonCountExpressionText => "8";
    public override string? MonsterSelectorBindingKey => nameof(MonsterRaceFiltersEnum.HiUndeadMonsterRaceFilter);
}
