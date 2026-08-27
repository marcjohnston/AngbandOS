namespace AngbandOS.GamePacks.Cthangband
{
    public class FreeActItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(FreeActAttribute), true) };
    }
}