namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class XtraShotsItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(XtraShotsAttribute), true) };
        public override string[] EffectDescription => new string[] { "It fires missiles excessively fast." };
    }
}