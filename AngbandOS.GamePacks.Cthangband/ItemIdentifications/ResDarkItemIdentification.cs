namespace AngbandOS.GamePacks.Cthangband
{
    public class ResDarkItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResDarkItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to dark." };
    }
}