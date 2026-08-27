namespace AngbandOS.GamePacks.Cthangband
{
    public class Vorpal1InChanceItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(Vorpal1InChanceAttribute), 1, null) };
    }
}