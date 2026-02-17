namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class HoldLifeItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(HoldLifeAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to life draining." };
    }
}