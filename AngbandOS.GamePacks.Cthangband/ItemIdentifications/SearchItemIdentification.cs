namespace AngbandOS.GamePacks.Cthangband
{
    public class SearchItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SearchItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your searching." };
    }
}