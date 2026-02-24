namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImpactItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ImpactItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It can cause earthquakes." };
    }
}