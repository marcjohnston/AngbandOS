namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class StrengthItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(StrengthAttribute), 1, null) };
    }
}