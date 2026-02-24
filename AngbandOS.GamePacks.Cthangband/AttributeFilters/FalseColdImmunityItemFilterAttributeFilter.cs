namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseColdImmunityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ImColdAttribute), false),
    };
}