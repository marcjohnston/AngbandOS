﻿namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoesNotHaveConfusionResistanceBoolPosFunction : BoolPosFunctionGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] { (nameof(FunctionsEnum.HasConfusionResistanceBoolFunction), false, 0) };
}
