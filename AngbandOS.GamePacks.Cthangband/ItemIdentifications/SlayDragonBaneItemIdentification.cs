namespace AngbandOS.GamePacks.Cthangband
{
    public class SlayDragonBaneItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SlayDragonBaneItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is a great bane of dragons." };
    }
}