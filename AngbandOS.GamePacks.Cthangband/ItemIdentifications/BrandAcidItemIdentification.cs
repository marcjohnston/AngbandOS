namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandAcidItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandAcidAttribute), true) };
        public override string[] EffectDescription => new string[] { "It does extra damage from acid." };
    }
}