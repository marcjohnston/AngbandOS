namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustWisItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SustWisItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your wisdom." };
    }
}