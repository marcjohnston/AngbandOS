namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreElecItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(IgnoreElecAttribute), true) };
        public override string[] EffectDescription => new string[] { "It cannot be harmed by electricity." };
    }
}