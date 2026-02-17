namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImElecItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ImElecAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides immunity to electricity." };
    }
}