﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BizarreA1xSummonScript : SummonScriptGameConfiguration
{
    public override string MonsterFilterBindingKey => nameof(MonsterRaceFiltersEnum.Bizarre1MonsterRaceFilter);
    public override string LevelRollExpression => "X";
    public override string[]? PreMessages => new string[] { "You concentrate on the Fool card..." };
    public override string[]? SuccessMessages => new string[] { "The summoned creature gets angry!" };
    public override string[]? FailureMessages => new string[] { "No-one ever turns up." };
}
