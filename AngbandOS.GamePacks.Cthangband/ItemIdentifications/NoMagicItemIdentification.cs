namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class NoMagicItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(NoMagicAttribute), true) };
        public override string[] EffectDescription => new string[] { "It produces an anti-magic shell." };
    }
}