namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseAcidImmunityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ImAcidAttribute), false),
    };
}