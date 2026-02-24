namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DrainExpItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(DrainExpItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It drains experience." };
    }
}