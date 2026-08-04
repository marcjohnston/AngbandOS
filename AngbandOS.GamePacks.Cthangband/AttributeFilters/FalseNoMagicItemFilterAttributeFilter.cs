namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseNoMagicItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(NoMagicAttribute), false),
    };
}