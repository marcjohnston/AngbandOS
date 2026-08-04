namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayGiantItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayGiantAttribute), true) };
    }
}