namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TeleportItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(TeleportAttribute), true) };
    }
}