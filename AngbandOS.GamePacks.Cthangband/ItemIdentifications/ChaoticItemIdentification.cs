namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChaoticItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ChaoticAttribute), true) };
        public override string[] EffectDescription => new string[] { "It produces chaotic effects." };
    }
}