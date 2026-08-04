namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ConstitutionItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(ConstitutionAttribute), 1, null) };
    }
}