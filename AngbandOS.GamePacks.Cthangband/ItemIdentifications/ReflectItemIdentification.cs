namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ReflectItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ReflectAttribute), true) };
        public override string[] EffectDescription => new string[] { "It reflects bolts and arrows." };
    }
}