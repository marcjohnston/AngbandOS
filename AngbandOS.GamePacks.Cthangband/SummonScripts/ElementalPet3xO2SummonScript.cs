// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElementalPet3xO2SummonScript : SummonScriptGameConfiguration
{
    public override string MonsterFilterBindingKey => nameof(MonsterRaceFiltersEnum.ElementalMonsterRaceFilter);
    public override string LevelRollExpression => "X*3/2";
    public override bool Pet => true;
    public override string GroupBooleanExpression => "X==50";
    public override string[]? SuccessMessages => new string[] { "An elemental materializes..." , "It seems obedient to you." };
    public override string[]? FailureMessages => new string[] { "No-one ever turns up." };
}

