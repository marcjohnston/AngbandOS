using AngbandOS.GamePacks.Cthangband.AttributeFilters;

namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ActivationItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ActivationItemIdentificationAttributeFilter);
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(SystemAttributes.ActivationAttribute) };
        public override string[] EffectDescription => new string[] { "It can be activated for...", "{0}", "...if it is being worn." };
    }
}