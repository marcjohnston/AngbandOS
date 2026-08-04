namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayEvilItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayEvilAttribute), true) };
    }
}