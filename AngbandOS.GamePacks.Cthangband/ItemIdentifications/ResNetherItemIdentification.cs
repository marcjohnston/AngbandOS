namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResNetherItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResNetherItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to nether." };
    }
}