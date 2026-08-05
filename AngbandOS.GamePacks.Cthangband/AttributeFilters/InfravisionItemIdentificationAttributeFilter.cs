namespace AngbandOS.GamePacks.Cthangband
{
    public class InfravisionItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings => new (string, int?, int?)[] { (nameof(InfraVisionAttribute), 1, null) };
    }
}