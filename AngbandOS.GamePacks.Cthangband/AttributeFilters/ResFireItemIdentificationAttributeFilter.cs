namespace AngbandOS.GamePacks.Cthangband
{
    public class ResFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResFireAttribute), true) };
    }
}