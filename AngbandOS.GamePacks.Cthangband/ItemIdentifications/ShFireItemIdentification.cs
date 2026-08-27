namespace AngbandOS.GamePacks.Cthangband
{
    public class ShFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ShFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It produces a fiery sheath." };
    }
}