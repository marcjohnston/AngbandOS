namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class XtraMightItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(XtraMightAttribute), true) };
        public override string[] EffectDescription => new string[] { "It fires missiles with extra might." };
    }
}