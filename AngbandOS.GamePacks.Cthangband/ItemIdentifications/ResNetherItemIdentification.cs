namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResNetherItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResNetherAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to nether." };
    }
}