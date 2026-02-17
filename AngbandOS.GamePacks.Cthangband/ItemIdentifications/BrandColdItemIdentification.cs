namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandColdItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandColdAttribute), true) };
        public override string[] EffectDescription => new string[] { "It does extra damage from frost." };
    }
}