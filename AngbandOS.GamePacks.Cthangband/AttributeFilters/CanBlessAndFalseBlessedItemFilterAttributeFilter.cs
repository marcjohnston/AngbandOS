namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanBlessAndFalseBlessedItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BlessedAttribute), false),
        (nameof(CanApplyBlessedArtifactBiasAttribute), true),
    };
}