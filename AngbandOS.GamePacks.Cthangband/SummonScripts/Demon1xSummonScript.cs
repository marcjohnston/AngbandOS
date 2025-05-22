// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Demon1xSummonScript : SummonScriptGameConfiguration
{
    public override string MonsterFilterBindingKey => nameof(MonsterRaceFiltersEnum.DemonMonsterRaceFilter);

    public override string[]? PreMessages => new string[] { "You concentrate on the image of a demon..." };
    public override string[]? FailureMessages => new string[] { "The summoned demon gets angry!" };
    public override string LevelRollExpression => "X";
}
