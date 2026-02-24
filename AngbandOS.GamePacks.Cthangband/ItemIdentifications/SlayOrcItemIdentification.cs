namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayOrcItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SlayOrcItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is especially deadly against orcs." };
    }
}