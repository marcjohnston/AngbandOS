namespace AngbandOS.GamePacks.Cthangband
{
    public class StrengthItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(BonusStrengthAttribute), 1, null) };
    }
}