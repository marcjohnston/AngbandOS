namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BlessedItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BlessedAttribute), true) };
        public override string[] EffectDescription => new string[] { "It has been blessed by the gods." };
    }
}