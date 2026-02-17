namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreAcidItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreAcidAttribute), true) };
        public override string[] EffectDescription => new string[] { "It cannot be harmed by acid." };
    }
}