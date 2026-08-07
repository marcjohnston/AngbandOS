namespace AngbandOS.GamePacks.Cthangband
{
    public class ConstitutionItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(BonusConstitutionAttribute), 1, null) };
    }
}