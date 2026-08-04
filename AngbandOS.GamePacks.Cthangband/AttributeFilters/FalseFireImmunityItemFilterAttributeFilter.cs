namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseFireImmunityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ImFireAttribute), false),
    };
}