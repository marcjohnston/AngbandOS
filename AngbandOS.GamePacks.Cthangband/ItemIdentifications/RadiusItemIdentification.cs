namespace AngbandOS.GamePacks.Cthangband
{
    public class RadiusItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(RadiusItemIdentificationAttributeFilter);
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(GlowRadiusAttribute) };
        public override string[] EffectDescription => new string[] { "It provides light (radius {0}) when fueled." };
    }
}