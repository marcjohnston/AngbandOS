namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlowDigestItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlowDigestAttribute), true) };
        public override string[] EffectDescription => new string[] { "It slows your metabolism." };
    }
}