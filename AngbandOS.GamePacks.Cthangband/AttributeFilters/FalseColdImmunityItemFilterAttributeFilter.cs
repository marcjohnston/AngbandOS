namespace AngbandOS.GamePacks.Cthangband;
public class FalseColdImmunityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ImColdAttribute), false),
    };
}