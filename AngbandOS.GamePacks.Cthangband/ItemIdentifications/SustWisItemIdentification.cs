namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustWisItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SustWisItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your wisdom." };
    }
}