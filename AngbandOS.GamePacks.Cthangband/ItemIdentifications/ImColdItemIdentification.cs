namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImColdItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImColdAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides immunity to cold." };
    }
}