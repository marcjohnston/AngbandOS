namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistDisenchantItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResDisenAttribute), false),
    };
}