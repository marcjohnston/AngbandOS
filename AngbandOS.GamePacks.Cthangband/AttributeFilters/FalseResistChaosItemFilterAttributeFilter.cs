namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistChaosItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResChaosAttribute), false),
    };
}