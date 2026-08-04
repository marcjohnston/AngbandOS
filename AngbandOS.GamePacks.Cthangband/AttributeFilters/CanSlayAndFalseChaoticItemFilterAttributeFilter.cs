namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseChaoticItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ChaoticAttribute), false),
    };
}