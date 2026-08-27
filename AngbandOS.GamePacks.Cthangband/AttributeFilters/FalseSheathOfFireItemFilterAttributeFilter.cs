namespace AngbandOS.GamePacks.Cthangband;
public class FalseSheathOfFireItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResFireAttribute), false),
        (nameof(CanProvideSheathOfFireAttribute), true)
    };
}