namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RadiusItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(RadiusItemIdentificationAttributeFilter);
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(RadiusAttribute) };
        public override string[] EffectDescription => new string[] { "It provides light (radius {0}) when fueled." };
    }
}