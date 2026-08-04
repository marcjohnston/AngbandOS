namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistElectricityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResElecAttribute), false),
    };
}