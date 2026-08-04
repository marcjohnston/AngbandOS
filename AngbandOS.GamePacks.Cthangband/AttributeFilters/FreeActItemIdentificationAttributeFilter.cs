namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FreeActItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(FreeActAttribute), true) };
    }
}