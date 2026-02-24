namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WisdomItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(WisdomAttribute), 1, null) };
    }
}