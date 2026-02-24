namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DexterityItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(DexterityItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your dexterity." };
    }
}