namespace AngbandOS.GamePacks.Cthangband
{
    public class ConstitutionItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ConstitutionItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your constitution." };
    }
}