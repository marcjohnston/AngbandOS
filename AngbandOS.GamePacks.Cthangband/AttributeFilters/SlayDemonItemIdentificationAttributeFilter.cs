namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDemonItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayDemonAttribute), true) };
    }
}