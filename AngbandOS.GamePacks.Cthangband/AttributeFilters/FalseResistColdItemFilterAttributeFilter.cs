namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistColdItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResColdAttribute), false),
    };
}