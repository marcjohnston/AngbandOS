namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistDisenchantItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResDisenAttribute), false),
    };
}