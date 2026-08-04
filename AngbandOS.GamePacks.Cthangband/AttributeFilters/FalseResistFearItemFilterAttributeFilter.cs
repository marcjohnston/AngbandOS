namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistFearItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResFearAttribute), false),
    };
}