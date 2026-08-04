namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistDarknessItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResDarkAttribute), false),
    };
}