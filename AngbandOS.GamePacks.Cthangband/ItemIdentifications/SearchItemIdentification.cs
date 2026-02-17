namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SearchItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SearchAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your searching." };
    }
}