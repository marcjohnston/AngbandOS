namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class StealthItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(StealthAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your stealth." };
    }
}