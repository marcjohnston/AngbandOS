namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BrandPoisItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(BrandPoisAttribute), true) };
        public override string[] EffectDescription => new string[] { "It poisons your foes." };
    }
}