namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResAcidItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ResAcidItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to acid." };
    }
}