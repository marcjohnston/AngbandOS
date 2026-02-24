namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResBlindItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResBlindItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to blindness." };
    }
}