namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TelepathyItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(TelepathyAttribute), true) };
        public override string[] EffectDescription => new string[] { "It gives telepathic powers." };
    }
}