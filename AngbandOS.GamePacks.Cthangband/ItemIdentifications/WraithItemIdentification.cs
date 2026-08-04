namespace AngbandOS.GamePacks.Cthangband
{
    public class WraithItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(WraithItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It renders you incorporeal." };
    }
}