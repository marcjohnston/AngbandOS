namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlowDigestItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SlowDigestItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It slows your metabolism." };
    }
}