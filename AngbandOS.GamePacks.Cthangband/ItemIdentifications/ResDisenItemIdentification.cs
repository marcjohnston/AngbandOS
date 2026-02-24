namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResDisenItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ResDisenItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to disenchantment." };
    }
}