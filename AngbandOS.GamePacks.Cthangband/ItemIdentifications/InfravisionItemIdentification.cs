namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class InfravisionItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(InfravisionItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your infravision." };
    }
}