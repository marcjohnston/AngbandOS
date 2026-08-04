namespace AngbandOS.GamePacks.Cthangband
{
    public class BrandFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(BrandFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It does extra damage from fire." };
    }
}