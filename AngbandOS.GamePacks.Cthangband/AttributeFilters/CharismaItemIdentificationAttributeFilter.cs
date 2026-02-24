namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class CharismaItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(CharismaAttribute), 1, null) };
    }
}