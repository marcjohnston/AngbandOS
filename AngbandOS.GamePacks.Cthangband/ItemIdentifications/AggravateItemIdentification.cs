namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AggravateItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(AggravateAttribute), true) };
        public override string[] EffectDescription => new string[] { "It aggravates nearby creatures." };
    }
}