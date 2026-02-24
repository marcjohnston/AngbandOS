namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistFearItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResFearAttribute), false),
    };
}