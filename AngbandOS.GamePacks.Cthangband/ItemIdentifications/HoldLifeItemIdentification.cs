namespace AngbandOS.GamePacks.Cthangband
{
    public class HoldLifeItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(HoldLifeItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to life draining." };
    }
}