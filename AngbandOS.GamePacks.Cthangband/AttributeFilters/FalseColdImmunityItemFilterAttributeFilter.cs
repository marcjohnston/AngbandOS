namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseColdImmunityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ImColdAttribute), false),
    };
}