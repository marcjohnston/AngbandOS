namespace AngbandOS.GamePacks.Cthangband
{
    public class ResFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to fire." };
    }
}