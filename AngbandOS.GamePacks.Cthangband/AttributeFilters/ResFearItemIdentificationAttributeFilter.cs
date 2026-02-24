namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResFearItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResFearAttribute), true) };
    }
}