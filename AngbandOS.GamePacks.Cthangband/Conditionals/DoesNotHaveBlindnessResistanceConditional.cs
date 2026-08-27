namespace AngbandOS.GamePacks.Cthangband;

public class DoesNotHaveBlindnessResistanceConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[] 
    { 
        (nameof(FunctionsEnum.HasBlindnessResistanceBoolFunction), false, 0) 
    };
}
