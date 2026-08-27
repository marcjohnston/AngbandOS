namespace AngbandOS.GamePacks.Cthangband;
public class FalseAcidImmunityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ImAcidAttribute), false),
    };
}