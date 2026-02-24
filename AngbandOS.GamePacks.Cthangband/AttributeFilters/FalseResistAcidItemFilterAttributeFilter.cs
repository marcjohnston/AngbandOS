namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistAcidItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResAcidAttribute), false),
    };
}