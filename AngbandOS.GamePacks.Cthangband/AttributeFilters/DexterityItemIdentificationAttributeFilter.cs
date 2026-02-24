namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DexterityItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(DexterityAttribute), 1, null) };
    }
}