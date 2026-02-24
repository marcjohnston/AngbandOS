namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TunnelItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(TunnelAttribute), 1, null) };
    }
}