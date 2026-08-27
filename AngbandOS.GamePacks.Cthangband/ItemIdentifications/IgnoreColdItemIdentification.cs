namespace AngbandOS.GamePacks.Cthangband
{
    public class IgnoreColdItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(IgnoreColdItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It cannot be harmed by cold." };
    }
}