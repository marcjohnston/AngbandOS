namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseBrandFireItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BrandFireAttribute), false),
    };
}