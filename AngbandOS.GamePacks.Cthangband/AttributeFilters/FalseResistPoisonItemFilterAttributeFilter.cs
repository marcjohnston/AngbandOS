namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistPoisonItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResPoisAttribute), false),
    };
}