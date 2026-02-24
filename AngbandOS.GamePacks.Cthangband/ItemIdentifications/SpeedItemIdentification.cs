namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SpeedItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SpeedItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your movement speed." };
    }
}