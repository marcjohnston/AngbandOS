namespace AngbandOS.GamePacks.Cthangband
{
    public class ReflectItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ReflectAttribute), true) };
    }
}