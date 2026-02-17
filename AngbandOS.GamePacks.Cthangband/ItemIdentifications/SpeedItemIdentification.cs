namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SpeedItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SpeedAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your movement speed." };
    }
}