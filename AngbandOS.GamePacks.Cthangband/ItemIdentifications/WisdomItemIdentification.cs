namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WisdomItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(WisdomAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your wisdom." };
    }
}