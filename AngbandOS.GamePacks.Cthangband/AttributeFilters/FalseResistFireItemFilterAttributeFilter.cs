namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistFireItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResFireAttribute), false),
    };
}