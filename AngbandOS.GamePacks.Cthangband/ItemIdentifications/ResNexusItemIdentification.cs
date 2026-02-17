namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResNexusItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResNexusAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to nexus." };
    }
}