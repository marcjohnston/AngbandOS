namespace AngbandOS.GamePacks.Cthangband
{
    public class IntelligenceItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(IntelligenceItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your intelligence." };
    }
}