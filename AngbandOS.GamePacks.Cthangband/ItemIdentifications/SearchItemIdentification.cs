namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SearchItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SearchItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your searching." };
    }
}