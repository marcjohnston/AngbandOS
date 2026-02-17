namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ShFireItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ShFireAttribute), true) };
        public override string[] EffectDescription => new string[] { "It produces a fiery sheath." };
    }
}