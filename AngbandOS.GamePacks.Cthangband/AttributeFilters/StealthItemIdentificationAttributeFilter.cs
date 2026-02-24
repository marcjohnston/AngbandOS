namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class StealthItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(StealthAttribute), 1, null) };
    }
}