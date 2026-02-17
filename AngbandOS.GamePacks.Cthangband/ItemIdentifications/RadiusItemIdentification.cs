namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RadiusItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(RadiusAttribute), 1, null), (nameof(BurnRateAttribute), 1, null) };
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(RadiusAttribute) };
        public override string[] EffectDescription => new string[] { "It provides light (radius {0}) when fueled." };
    }
}