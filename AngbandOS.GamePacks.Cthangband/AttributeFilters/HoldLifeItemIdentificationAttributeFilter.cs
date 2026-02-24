namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class HoldLifeItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(HoldLifeAttribute), true) };
    }
}