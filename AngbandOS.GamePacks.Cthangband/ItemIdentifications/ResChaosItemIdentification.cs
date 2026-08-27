namespace AngbandOS.GamePacks.Cthangband
{
    public class ResChaosItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResChaosItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to chaos." };
    }
}