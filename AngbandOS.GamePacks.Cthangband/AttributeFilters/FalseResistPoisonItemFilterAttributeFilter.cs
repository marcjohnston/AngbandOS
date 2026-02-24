namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseResistPoisonItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResPoisAttribute), false),
    };
}