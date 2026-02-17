namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreFireItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreFireAttribute), true) };
        public override string[] EffectDescription => new string[] { "It cannot be harmed by fire." };
    }
}