namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResBlindItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResBlindAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to blindness." };
    }
}