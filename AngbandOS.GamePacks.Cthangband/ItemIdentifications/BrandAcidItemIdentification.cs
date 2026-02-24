namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandAcidItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(BrandAcidItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It does extra damage from acid." };
    }
}