namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SpeedItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SpeedItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your movement speed." };
    }
}