namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(ResFireAttribute), true) };
    }
}