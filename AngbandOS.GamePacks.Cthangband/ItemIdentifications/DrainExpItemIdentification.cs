namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DrainExpItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(DrainExpAttribute), true) };
        public override string[] EffectDescription => new string[] { "It drains experience." };
    }
}