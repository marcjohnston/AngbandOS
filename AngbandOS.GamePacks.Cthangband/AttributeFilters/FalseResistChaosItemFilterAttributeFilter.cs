namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistChaosItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResChaosAttribute), false),
    };
}