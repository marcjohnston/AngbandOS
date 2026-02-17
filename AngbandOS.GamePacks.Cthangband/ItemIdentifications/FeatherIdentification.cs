namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FeatherIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(FeatherAttribute), true) };
        public override string[] EffectDescription => new string[] { "It allows you to levitate." };
    }
}