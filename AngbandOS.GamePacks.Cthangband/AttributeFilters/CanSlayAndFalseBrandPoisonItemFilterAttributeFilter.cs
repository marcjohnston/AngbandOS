namespace AngbandOS.GamePacks.Cthangband;
public class CanSlayAndFalseBrandPoisonItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandPoisAttribute), false),
    };
}