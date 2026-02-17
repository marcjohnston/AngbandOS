namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImFireItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImFireAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides immunity to fire." };
    }
}