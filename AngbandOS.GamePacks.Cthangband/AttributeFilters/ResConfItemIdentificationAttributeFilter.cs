namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResConfItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResConfAttribute), true) };
    }
}