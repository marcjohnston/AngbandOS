namespace AngbandOS.GamePacks.Cthangband;
public class FalseResistFireItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResFireAttribute), false),
    };
}