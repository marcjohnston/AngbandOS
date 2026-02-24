namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class XtraShotsItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(XtraShotsItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It fires missiles excessively fast." };
    }
}