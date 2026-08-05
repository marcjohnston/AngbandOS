namespace AngbandOS.GamePacks.Cthangband
{
    public class PermanentLightRadiusItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(PermanentLightRadiusItemIdentificationAttributeFilter);
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(GlowRadiusAttribute) };
        public override string[] EffectDescription => new string[] { "It provides light (radius {0}) forever.", "It provides permanent light." };
    }
}