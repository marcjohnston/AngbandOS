namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImAcidItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImAcidAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides immunity to acid." };
    }
}