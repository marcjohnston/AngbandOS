namespace AngbandOS.GamePacks.Cthangband
{
    public class DexterityItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(BonusDexterityAttribute), 1, null) };
    }
}