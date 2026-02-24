namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(BrandFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It does extra damage from fire." };
    }
}