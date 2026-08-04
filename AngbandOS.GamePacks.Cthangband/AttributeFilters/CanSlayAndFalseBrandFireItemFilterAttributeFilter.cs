namespace AngbandOS.GamePacks.Cthangband;
public class CanSlayAndFalseBrandFireItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandFireAttribute), false),
    };
}