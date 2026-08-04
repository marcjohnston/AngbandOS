namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayAnimalItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayAnimalAttribute), true) };
    }
}