namespace AngbandOS.GamePacks.Cthangband
{
    public class SeeInvisItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SeeInvisAttribute), true) };
    }
}