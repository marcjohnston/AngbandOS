namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResPoisItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResPoisAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to poison." };
    }
}