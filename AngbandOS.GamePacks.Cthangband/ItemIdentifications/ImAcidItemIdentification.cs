namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImAcidItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ImAcidItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides immunity to acid." };
    }
}