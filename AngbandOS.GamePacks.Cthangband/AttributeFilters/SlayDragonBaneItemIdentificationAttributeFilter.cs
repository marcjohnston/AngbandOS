namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayDragonBaneItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SlayDragonAttribute), 3, null) };
    }
}