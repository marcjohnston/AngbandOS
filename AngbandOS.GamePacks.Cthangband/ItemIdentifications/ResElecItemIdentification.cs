namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResElecItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResElecItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to electricity." };
    }
}