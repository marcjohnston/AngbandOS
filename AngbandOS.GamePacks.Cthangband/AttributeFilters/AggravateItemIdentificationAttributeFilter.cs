namespace AngbandOS.GamePacks.Cthangband
{
    public class AggravateItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(AggravateAttribute), true) };
    }
}