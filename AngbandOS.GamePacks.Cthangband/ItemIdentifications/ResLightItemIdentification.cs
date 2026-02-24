namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResLightItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResLightItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to light." };
    }
}