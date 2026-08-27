namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistNetherItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResNetherAttribute), false),
    };
}