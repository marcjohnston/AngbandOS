namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoesNotHaveFreeActionBoolPosFunction : BoolPosFunctionGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] { (nameof(FunctionsEnum.HasFreeActionBoolFunction), false, 0) };
}
