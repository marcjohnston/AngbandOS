namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanBlessAndFalseBlessedItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BlessedAttribute), false),
        (nameof(CanApplyBlessedArtifactBiasAttribute), true),
    };
}