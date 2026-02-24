namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RegenItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings => new (string AttributeKey, bool?[] DesiredValue)[] { (nameof(RegenAttribute), new bool?[] { true }) };
    }
}