namespace AngbandOS.GamePacks.Cthangband
{
    public class InfravisionItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(InfravisionItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your infravision." };
    }
}