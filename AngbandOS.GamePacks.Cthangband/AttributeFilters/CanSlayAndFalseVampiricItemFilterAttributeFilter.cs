namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseVampiricItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(VampiricAttribute), false),
    };
}