namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistElectricityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResElecAttribute), false),
    };
}