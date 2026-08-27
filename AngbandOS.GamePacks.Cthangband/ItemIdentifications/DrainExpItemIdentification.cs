namespace AngbandOS.GamePacks.Cthangband
{
    public class DrainExpItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(DrainExpItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It drains experience." };
    }
}