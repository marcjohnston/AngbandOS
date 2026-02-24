namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PermanentCursedItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(PermanentCursedItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is permanently cursed." };
    }
}