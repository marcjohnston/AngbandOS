namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResShardsItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResShardsAttribute), true) };
    }
}