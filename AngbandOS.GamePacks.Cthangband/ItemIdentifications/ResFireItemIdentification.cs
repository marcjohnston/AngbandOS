namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResFireItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResFireAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to fire." };
    }
}