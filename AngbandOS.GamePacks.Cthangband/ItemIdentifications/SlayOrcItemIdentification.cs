namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayOrcItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayOrcAttribute), true) };
        public override string[] EffectDescription => new string[] { "It is especially deadly against orcs." };
    }
}