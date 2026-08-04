namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class VampiricItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(VampiricAttribute), true) };
    }
}