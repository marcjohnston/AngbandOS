namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandColdItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(BrandColdItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It does extra damage from frost." };
    }
}