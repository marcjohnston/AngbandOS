namespace AngbandOS.GamePacks.Cthangband
{
    public class CharismaItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(BonusCharismaAttribute), 1, null) };
    }
}