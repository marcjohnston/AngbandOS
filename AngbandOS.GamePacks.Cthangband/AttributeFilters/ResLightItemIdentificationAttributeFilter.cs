namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResLightItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResLightAttribute), true) };
    }
}