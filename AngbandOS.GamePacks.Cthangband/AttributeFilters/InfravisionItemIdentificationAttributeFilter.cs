namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class InfravisionItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(InfravisionAttribute), 1, null) };
    }
}