namespace AngbandOS.GamePacks.Cthangband
{
    public class ResConfItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResConfItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to confusion." };
    }
}