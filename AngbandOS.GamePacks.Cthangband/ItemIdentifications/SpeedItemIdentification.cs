namespace AngbandOS.GamePacks.Cthangband
{
    public class SpeedItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SpeedItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your movement speed." };
    }
}