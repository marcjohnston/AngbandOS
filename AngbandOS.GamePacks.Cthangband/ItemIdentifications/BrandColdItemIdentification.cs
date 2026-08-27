namespace AngbandOS.GamePacks.Cthangband
{
    public class BrandColdItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(BrandColdItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It does extra damage from frost." };
    }
}