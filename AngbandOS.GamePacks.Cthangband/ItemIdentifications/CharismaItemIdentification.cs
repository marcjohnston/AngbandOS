namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class CharismaItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(CharismaItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your charisma." };
    }
}