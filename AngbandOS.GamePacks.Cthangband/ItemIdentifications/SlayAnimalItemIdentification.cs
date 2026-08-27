namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayAnimalItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SlayAnimalItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is especially deadly against natural creatures." };
    }
}