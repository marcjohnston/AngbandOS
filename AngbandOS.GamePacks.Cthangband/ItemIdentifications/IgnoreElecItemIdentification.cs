namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreElecItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(IgnoreElecItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It cannot be harmed by electricity." };
    }
}