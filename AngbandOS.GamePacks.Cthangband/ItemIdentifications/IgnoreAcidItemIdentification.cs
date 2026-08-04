namespace AngbandOS.GamePacks.Cthangband
{
    public class IgnoreAcidItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(IgnoreAcidItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It cannot be harmed by acid." };
    }
}