namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImElecItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ImElecItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides immunity to electricity." };
    }
}