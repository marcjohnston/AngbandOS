namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResNexusItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ResNexusItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to nexus." };
    }
}