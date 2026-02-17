namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayTrollItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayTrollAttribute), true) };
        public override string[] EffectDescription => new string[] { "It is especially deadly against trolls." };
    }
}