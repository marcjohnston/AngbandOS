namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResElecItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResElecAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to electricity." };
    }
}