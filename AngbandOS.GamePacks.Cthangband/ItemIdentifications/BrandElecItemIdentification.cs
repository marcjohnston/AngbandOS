namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandElecItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandElecAttribute), true) };
        public override string[] EffectDescription => new string[] { "It does extra damage from electricity." };
    }
}