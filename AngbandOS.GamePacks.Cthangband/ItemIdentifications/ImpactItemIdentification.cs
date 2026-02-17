namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImpactItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImpactAttribute), true) };
        public override string[] EffectDescription => new string[] { "It can cause earthquakes." };
    }
}