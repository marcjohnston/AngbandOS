namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistFearItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResFearAttribute), false),
    };
}