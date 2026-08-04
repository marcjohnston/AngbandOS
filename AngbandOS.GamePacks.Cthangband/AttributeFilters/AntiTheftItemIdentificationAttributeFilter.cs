namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AntiTheftItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(AntiTheftAttribute), true) };
    }
}