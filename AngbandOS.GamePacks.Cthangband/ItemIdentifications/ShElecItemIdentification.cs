namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ShElecItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ShElecItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It produces an electric sheath." };
    }
}