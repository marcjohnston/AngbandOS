namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class VampiricItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(VampiricAttribute), true) };
        public override string[] EffectDescription => new string[] { "It drains life from your foes." };
    }
}