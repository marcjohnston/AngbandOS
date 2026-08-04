namespace AngbandOS.GamePacks.Cthangband
{
    public class TunnelItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(TunnelAttribute), 1, null) };
    }
}