namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayDemonItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayDemonAttribute), true) };
    }
}