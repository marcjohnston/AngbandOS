namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IntelligenceItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(IntelligenceItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your intelligence." };
    }
}