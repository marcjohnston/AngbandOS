namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ShElecItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ShElecItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It produces an electric sheath." };
    }
}