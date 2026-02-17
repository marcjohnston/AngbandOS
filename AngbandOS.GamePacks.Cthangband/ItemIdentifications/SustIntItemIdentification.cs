namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustIntItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SustIntAttribute), true) };
        public override string[] EffectDescription => new string[] { "It sustains your intelligence." };
    }
}