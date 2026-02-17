namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WraithItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(WraithAttribute), true) };
        public override string[] EffectDescription => new string[] { "It renders you incorporeal." };
    }
}