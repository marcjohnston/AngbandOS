namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayTrollItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayTrollAttribute), true) };
    }
}