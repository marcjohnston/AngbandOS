namespace AngbandOS.GamePacks.Cthangband
{
    public class NoMagicItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(NoMagicItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It produces an anti-magic shell." };
    }
}