namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandFireItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandFireAttribute), true) };
        public override string[] EffectDescription => new string[] { "It does extra damage from fire." };
    }
}