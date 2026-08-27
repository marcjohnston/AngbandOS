namespace AngbandOS.GamePacks.Cthangband
{
    public class ResNexusItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResNexusAttribute), true) };
    }
}