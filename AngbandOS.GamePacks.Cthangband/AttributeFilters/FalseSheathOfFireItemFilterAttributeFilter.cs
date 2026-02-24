namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseSheathOfFireItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResFireAttribute), false),
        (nameof(CanProvideSheathOfFireAttribute), true)
    };
}