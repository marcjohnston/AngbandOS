namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseNoMagicItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(NoMagicAttribute), false),
    };
}