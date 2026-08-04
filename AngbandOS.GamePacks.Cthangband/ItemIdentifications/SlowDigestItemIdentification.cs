namespace AngbandOS.GamePacks.Cthangband
{
    public class SlowDigestItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SlowDigestItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It slows your metabolism." };
    }
}