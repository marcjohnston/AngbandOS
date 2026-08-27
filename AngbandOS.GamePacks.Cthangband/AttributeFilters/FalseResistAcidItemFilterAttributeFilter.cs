namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistAcidItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResAcidAttribute), false),
    };
}