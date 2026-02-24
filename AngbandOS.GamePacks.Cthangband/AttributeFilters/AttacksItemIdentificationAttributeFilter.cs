namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AttacksItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(AttacksAttribute), 1, null) };
    }
}