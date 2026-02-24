namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandElecItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(BrandElecItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It does extra damage from electricity." };
    }
}