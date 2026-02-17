namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreColdItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreColdAttribute), true) };
        public override string[] EffectDescription => new string[] { "It cannot be harmed by cold." };
    }
}