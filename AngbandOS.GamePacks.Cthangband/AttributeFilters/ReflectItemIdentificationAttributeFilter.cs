namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ReflectItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ReflectAttribute), true) };
    }
}