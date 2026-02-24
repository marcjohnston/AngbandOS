namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class BlessedItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(BlessedItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It has been blessed by the gods." };
    }
}