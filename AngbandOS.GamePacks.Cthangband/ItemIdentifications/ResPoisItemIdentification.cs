namespace AngbandOS.GamePacks.Cthangband
{
    public class ResPoisItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResPoisItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to poison." };
    }
}