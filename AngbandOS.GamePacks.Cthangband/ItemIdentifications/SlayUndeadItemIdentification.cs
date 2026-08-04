namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayUndeadItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SlayUndeadItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It strikes at undead with holy wrath." };
    }
}