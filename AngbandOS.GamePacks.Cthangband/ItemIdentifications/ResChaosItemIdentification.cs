namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResChaosItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResChaosAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to chaos." };
    }
}