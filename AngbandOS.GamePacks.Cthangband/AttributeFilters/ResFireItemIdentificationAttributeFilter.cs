namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResFireItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResFireAttribute), true) };
    }
}