namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayOrcItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SlayOrcItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is especially deadly against orcs." };
    }
}