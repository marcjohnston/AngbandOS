namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistConfusionItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResConfAttribute), false),
    };
}