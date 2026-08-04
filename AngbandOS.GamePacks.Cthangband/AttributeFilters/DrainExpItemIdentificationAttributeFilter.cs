namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DrainExpItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(DrainExpAttribute), true) };
    }
}