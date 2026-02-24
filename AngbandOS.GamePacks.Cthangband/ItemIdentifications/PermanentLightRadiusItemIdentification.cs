namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PermanentLightRadiusItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(PermanentLightRadiusItemIdentificationAttributeFilter);
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(RadiusAttribute) };
        public override string[] EffectDescription => new string[] { "It provides light (radius {0}) forever.", "It provides permanent light." };
    }
}