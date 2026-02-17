namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResDisenItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResDisenAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to disenchantment." };
    }
}