namespace AngbandOS.GamePacks.Cthangband
{
    public class HoldLifeItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(HoldLifeAttribute), true) };
    }
}