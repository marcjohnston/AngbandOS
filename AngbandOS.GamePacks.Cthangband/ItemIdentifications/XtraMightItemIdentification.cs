namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class XtraMightItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(XtraMightItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It fires missiles with extra might." };
    }
}