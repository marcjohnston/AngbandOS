namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResConfItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResConfAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to confusion." };
    }
}