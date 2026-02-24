namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImpactItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ImpactItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It can cause earthquakes." };
    }
}