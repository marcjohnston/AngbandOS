namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PermanentLightRadiusItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(RadiusAttribute), 1, null), (nameof(BurnRateAttribute), 0, 0) };
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(RadiusAttribute) };
        public override string[] EffectDescription => new string[] { "It provides light (radius {0}) forever.", "It provides permanent light." };
    }
}