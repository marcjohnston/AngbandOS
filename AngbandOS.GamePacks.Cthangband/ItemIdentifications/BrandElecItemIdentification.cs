namespace AngbandOS.GamePacks.Cthangband
{
    public class BrandElecItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(BrandElecItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It does extra damage from electricity." };
    }
}