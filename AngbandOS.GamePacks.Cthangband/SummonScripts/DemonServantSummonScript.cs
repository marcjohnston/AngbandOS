// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DemonServantSummonScript : SummonScriptGameConfiguration
{
    public override string MonsterFilterBindingKey => nameof(MonsterRaceFiltersEnum.DemonMonsterRaceFilter);

    public override string LevelRollExpression => "X*3/2";

    public override string[]? FailureMessages => new string[] { "No-one ever turns up." };
    public override string[]? SuccessMessages => new string[] { "The area fills with a stench of sulphur and brimstone.", "'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'" };
}
