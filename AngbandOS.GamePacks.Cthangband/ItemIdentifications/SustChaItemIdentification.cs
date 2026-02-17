namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustChaItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SustChaAttribute), true) };
        public override string[] EffectDescription => new string[] { "It sustains your charisma." };
    }
}