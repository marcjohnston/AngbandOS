namespace AngbandOS.GamePacks.Cthangband
{
    public class SpeedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SpeedAttribute), 1, null) };
    }
}