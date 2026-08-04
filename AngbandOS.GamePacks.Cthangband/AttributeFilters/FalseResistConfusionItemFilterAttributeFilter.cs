namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistConfusionItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResConfAttribute), false),
    };
}