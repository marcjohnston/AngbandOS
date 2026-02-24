namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistNetherItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResNetherAttribute), false),
    };
}