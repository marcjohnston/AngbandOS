namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResFearItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResFearAttribute), true) };
    }
}