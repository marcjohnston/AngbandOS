namespace AngbandOS.GamePacks.Cthangband;
public class FalseFireImmunityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ImFireAttribute), false),
    };
}