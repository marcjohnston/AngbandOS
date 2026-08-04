namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayDragonItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SlayDragonAttribute), 1, 2) };
    }
}