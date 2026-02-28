namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoesNotHaveFreeActionConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] { (nameof(FunctionsEnum.HasFreeActionBoolFunction), false, 0) };
}
