namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RadiusItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(RadiusAttribute), 1, null), (nameof(BurnRateAttribute), 1, null) };
    }
}