namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistDarknessItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResDarkAttribute), false),
    };
}