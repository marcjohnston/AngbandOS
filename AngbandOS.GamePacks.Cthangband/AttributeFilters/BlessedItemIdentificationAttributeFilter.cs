namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BlessedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(BlessedAttribute), true) };
    }
}