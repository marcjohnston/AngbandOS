namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImpactItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ImpactAttribute), true) };
    }
}