namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDragonItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SlayDragonAttribute), 1, 2) };
    }
}