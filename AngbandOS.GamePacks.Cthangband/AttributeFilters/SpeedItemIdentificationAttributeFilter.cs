namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SpeedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SpeedAttribute), 1, null) };
    }
}