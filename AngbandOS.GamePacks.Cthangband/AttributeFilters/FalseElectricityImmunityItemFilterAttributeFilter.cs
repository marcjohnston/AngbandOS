namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseElectricityImmunityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ImElecAttribute), false),
    };
}