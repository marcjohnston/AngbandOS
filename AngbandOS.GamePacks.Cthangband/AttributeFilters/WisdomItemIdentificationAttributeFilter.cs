namespace AngbandOS.GamePacks.Cthangband
{
    public class WisdomItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(BonusWisdomAttribute), 1, null) };
    }
}