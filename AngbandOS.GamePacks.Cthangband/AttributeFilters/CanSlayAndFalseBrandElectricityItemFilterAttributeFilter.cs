namespace AngbandOS.GamePacks.Cthangband;
public class CanSlayAndFalseBrandElectricityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandElecAttribute), false),
    };
}