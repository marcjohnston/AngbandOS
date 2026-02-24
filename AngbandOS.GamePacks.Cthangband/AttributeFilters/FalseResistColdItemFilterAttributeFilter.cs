namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistColdItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResColdAttribute), false),
    };
}