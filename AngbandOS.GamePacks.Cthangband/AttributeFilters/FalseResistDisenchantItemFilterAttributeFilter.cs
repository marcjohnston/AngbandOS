namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistDisenchantItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResDisenAttribute), false),
    };
}