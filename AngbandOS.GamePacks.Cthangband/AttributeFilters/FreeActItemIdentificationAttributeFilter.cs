namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FreeActItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(FreeActAttribute), true) };
    }
}