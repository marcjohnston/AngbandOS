namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDragonBaneItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SlayDragonAttribute), 3, null) };
    }
}