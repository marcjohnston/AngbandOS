namespace AngbandOS.GamePacks.Cthangband
{
    public class PermanentLightRadiusItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(RadiusAttribute), 1, null), (nameof(BurnRateAttribute), 0, 0) };
    }
}