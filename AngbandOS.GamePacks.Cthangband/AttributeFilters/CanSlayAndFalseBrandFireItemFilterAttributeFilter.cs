namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseBrandFireItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandFireAttribute), false),
    };
}