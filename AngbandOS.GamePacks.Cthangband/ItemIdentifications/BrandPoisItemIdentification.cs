namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandPoisItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(BrandPoisItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It poisons your foes." };
    }
}